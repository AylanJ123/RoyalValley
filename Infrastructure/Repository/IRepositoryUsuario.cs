using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryUsuario
    {
        Usuario GetUsuario(string email, byte[] pass);
    }
}
