using Infrastructure.Utils;
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
    public class ServiceCobro : IServiceCobro
    {
        public IEnumerable<Cobro> GetCobros()
        {
            IRepositoryCobro repository = new RepositoryCobro();
            return repository.GetCobros();
        }

        public Cobro GetCobroByKeys(DateTime fecha, int idResidencia, int idPlanCobro)
        {
            IRepositoryCobro repository = new RepositoryCobro();
            return repository.GetCobroByKeys(fecha, idResidencia, idPlanCobro);
        }
    }
}
