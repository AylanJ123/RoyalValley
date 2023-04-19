using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceEdificioPublico : IServiceEdificioPublico
    {
        public IEnumerable<EdificioPublico> GetEdificios()
        {
            RepositoryEdificioPublico _RepositoryEdificio = new RepositoryEdificioPublico();
            return _RepositoryEdificio.GetEdificios();
        }
    }
}
