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

        public Cobro CreateCobro(DateTime fecha, int planSelected, int idResidencia)
        {
            IRepositoryPlanCobro repositoryP = new RepositoryPlanCobro();
            IRepositoryResidencia repositoryR = new RepositoryResidencia();
            IRepositoryCobro repository = new RepositoryCobro();
            PlanCobro plan = repositoryP.GetPlanCobroByID(planSelected);
            Residencia residencia = repositoryR.GetResidenciaByID(idResidencia);
            Cobro cobro = new Cobro()
            {
                fecha = fecha,
                IDPlanCobro = planSelected,
                fechaPago = null,
                IDResidencia = idResidencia,
                pagado = false,
                total = CalculateTotal(plan.Rubro, residencia.montoMensual)
            };
            return repository.CreateCobro(cobro);
        }

        private decimal CalculateTotal(ICollection<Rubro> rubros, decimal residenciaValue)
        {
            decimal total = 0;
            foreach (Rubro rubro in rubros)
                total += rubro.porcentual ? rubro.monto * residenciaValue : rubro.monto;
            return total;
        }

    }
}
