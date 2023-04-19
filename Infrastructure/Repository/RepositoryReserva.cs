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
    public class RepositoryReserva : IRepositoryReserva
    {

        public IEnumerable<Reserva> GetReservas()
        {
            try
            {
                IEnumerable<Reserva> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Reserva.Include("EdificioPublico").Include("Usuario").ToList();
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
        public Reserva Save(Reserva reserva)
        {
            int retorno = 0;
            Reserva oReserva = null;
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oReserva = GetReservaByKeys(reserva.fecha, reserva.IDEdificio);
                IRepositoryRubro _RepositoryRubro = new RepositoryRubro();
                if (oReserva == null)
                {
                    ctx.Reserva.Add(reserva);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Reserva.Add(reserva);
                    ctx.Entry(reserva).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }
            if (retorno >= 0)
                oReserva = GetReservaByKeys(reserva.fecha, reserva.IDEdificio);
            return oReserva;
        }
        public IEnumerable<Reserva> GerReservasByEdificio(int edificioId)
        {
            try
            {
                IEnumerable<Reserva> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Reserva.Include("EdificioPublico").Include("Usuario").Where(res => res.EdificioPublico.ID == edificioId).ToList();
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

        public Reserva GetReservaByKeys(DateTime fecha, int idEdificio)
        {
            try
            {
                Reserva reserva = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    reserva = cx.Reserva.Include("EdificioPublico").Include("Usuario").Where(res => res.IDEdificio == idEdificio && res.fecha.CompareTo(fecha) == 0).FirstOrDefault();
                }
                return reserva;
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
