using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceIncidencia : IServiceIncidencia
    {
        public IEnumerable<Incidencia> GetIncidencias()
        {
            IRepositoryIncidencia _RepositoryIncidencia = new RepositoryIncidencia();
            return _RepositoryIncidencia.GetIncidencias();
        }

        public Incidencia New(Incidencia incidencia)
        {
            IRepositoryIncidencia _RepositoryIncidencia = new RepositoryIncidencia();
            incidencia.fecha = DateTime.Now;
            incidencia.estado = 0;
            incidencia.IDUsuario = 1001; //Temporal
            return _RepositoryIncidencia.Save(incidencia);
        }

        public Incidencia UpdateState(int id)
        {
            IRepositoryIncidencia _RepositoryIncidencia = new RepositoryIncidencia();
            Incidencia incidencia = _RepositoryIncidencia.GetIncidenciaByID(id);
            incidencia.estado = (byte) (incidencia.estado == 0 ?  1 : 0);
            return _RepositoryIncidencia.Save(incidencia);
        }
    }
}
