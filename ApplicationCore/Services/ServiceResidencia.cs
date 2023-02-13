using Infraestructure.Utils;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceResidencia : IServiceResidencia
    {
        public IEnumerable<Residencia> GetResidencias()
        {
            IRepositoryResidencia repository = new RepositoryResidencia();
            return repository.GetResidencias();
        }

        public Residencia GetResidenciaByID(int id)
        {
            IRepositoryResidencia repository = new RepositoryResidencia();
            return repository.GetResidenciaByID(id);
        }
    }
}
