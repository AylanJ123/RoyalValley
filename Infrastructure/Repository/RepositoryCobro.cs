using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryCobro : IRepositoryCobro
    {
        public IEnumerable<Cobro> GetCobros()
        {
            try
            {
                IEnumerable<Cobro> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Cobro.Include("Residencia").Include("Residencia.Usuario").Include("PlanCobro").Include("PlanCobro.Rubro").ToList();
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

        public Cobro GetCobroByKeys(DateTime fecha, int idResidencia, int idPlanCobro)
        {
            try
            {
                Cobro cob = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    cob = cx.Cobro.Include("Residencia")
                        .Include("Residencia.Usuario")
                        .Include("PlanCobro")
                        .Include("PlanCobro.Rubro")
                        .Where(cobro => cobro.fecha.CompareTo(fecha) == 0 && cobro.Residencia.ID == idResidencia && cobro.PlanCobro.ID == idPlanCobro)
                        .FirstOrDefault();
                }
                return cob;
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

        public IEnumerable<Cobro> GetCobrosForResidencia(int idResidencia)
        {
            try
            {
                IEnumerable<Cobro> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Cobro.Include("Residencia")
                        .Include("Residencia.Usuario")
                        .Include("PlanCobro")
                        .Include("PlanCobro.Rubro")
                        .Where(cobro => cobro.Residencia.ID == idResidencia)
                        .ToList();
                }
                return list;
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

    }
}
