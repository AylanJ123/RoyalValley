using Infrastructure.Models;
using Infrastructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryUsuario : IRepositoryUsuario
    {
        public Usuario GetUsuario(string email, byte[] pass)
        {
            try
            {
                Usuario usuario = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    usuario = cx.Usuario.Where(us => us.correo.Equals(email)).FirstOrDefault();
                    if (usuario != null && !Crypto.CompareBytes(usuario.contrasena, pass)) usuario = null;
                }
                return usuario;
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
