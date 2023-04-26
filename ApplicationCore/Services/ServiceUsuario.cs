using ApplicationCore.Utils.Crypto;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        public Usuario GetUsuario(string email, string pass)
        {
            IRepositoryUsuario repository = new RepositoryUsuario();
            byte[] crytpPasswd = Cryptography.EncrypthAES(pass);
            return repository.GetUsuario(email, crytpPasswd);
        }
    }
}
