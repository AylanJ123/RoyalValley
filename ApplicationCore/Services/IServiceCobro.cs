using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceCobro
    {
        IEnumerable<Cobro> GetCobros();
        Cobro GetCobroByKeys(DateTime fecha, int idResidencia, int idPlanCobro);
    }
}
