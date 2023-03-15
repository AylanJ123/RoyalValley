using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public class RepositoryIncidencia : IRepositoryIncidencia
    {

        public IEnumerable<Incidencia> GetIncidencias()
        {
            try
            {
                IEnumerable<Incidencia> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Incidencia.ToList();
                }
                return list;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "Error en la conexión a la base de datos";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "Error desconocido";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw ex;
            }
        }

        public Incidencia GetIncidenciaByID(int id)
        {
            try
            {
                Incidencia incidencia = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    incidencia = cx.Incidencia.Where(inc => inc.ID == id).FirstOrDefault();
                }
                return incidencia;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Incidencia Save(Incidencia incidencia)
        {
            int retorno = 0;
            Incidencia oIncidencia = null;
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oIncidencia = GetIncidenciaByID(incidencia.ID);
                IRepositoryIncidencia _RepositoryIncidencia = new RepositoryIncidencia();
                if (oIncidencia == null)
                {
                    ctx.Incidencia.Add(incidencia);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Incidencia.Add(incidencia);
                    ctx.Entry(incidencia).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }
            if (retorno >= 0) oIncidencia = GetIncidenciaByID(incidencia.ID);
            return oIncidencia;
        }

    }
}
