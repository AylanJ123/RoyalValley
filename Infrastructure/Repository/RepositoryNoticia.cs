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
    public class RepositoryNoticia : IRepositoryNoticia
    {
        public IEnumerable<Noticias> GetNoticias()
        {
            try
            {
                IEnumerable<Noticias> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.Noticias.ToList();
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

        public Noticias GetNoticiaByNombre(string nombre)
        {
            try
            {
                Noticias noticia = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    noticia = cx.Noticias.Where(res => res.nombre == nombre).FirstOrDefault();
                }
                return noticia;
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

        public Noticias Save(Noticias noticia)
        {
            int retorno = 0;
            Noticias oNoticia = null;
            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oNoticia = GetNoticiaByNombre(noticia.nombre);
                IRepositoryNoticia _RepositoryNoticia = new RepositoryNoticia();
                if (oNoticia == null)
                {
                    ctx.Noticias.Add(noticia);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.Noticias.Add(noticia);
                    ctx.Entry(noticia).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                }
            }
            if (retorno >= 0) oNoticia = GetNoticiaByNombre(noticia.nombre);
            return oNoticia;
        }

    }
}
