using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryCobro
    {
        IEnumerable<Cobro> GetCobros();
        Cobro GetCobroByKeys(DateTime fecha, int idResidencia, int idPlanCobro);
        IEnumerable<Cobro> GetCobrosForResidencia(int idResidencia);
    }
}
