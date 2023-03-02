using Infrastructure.Utils;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.DTOS;

namespace ApplicationCore.Services
{
    public class ServiceEstadoCuenta : IServiceEstadoCuenta
    {
        public IEnumerable<EstadoCuenta> GetEstadosCuenta()
        {
            List<EstadoCuenta> estados = new List<EstadoCuenta>();
            IRepositoryCobro repository = new RepositoryCobro();
            IEnumerable<Cobro> cobros = repository.GetCobros();
            foreach (Cobro cobro in cobros)
            {
                EstadoCuenta estado = estados.Find(est => est.Residencia.ID == cobro.Residencia.ID);
                if (estado == null)
                {
                    estado = new EstadoCuenta(new List<Cobro>() { cobro });
                    estados.Add(estado);
                }
                estado.Cobros.Add(cobro);
            }
            return estados;
        }

        public EstadoCuenta GetEstadoCuentaFromResidencia(int idResidencia)
        {
            IRepositoryCobro repository = new RepositoryCobro();
            IEnumerable<Cobro> cobros = repository.GetCobrosForResidencia(idResidencia);
            EstadoCuenta estado = new EstadoCuenta(cobros.ToList());
            return estado;
        }
    }
}
