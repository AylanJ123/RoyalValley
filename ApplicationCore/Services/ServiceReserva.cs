using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReserva : IServiceReserva
    {
        public IEnumerable<Reserva> GetReservas()
        {
            IRepositoryReserva _RepositoryReserva = new RepositoryReserva();
            return _RepositoryReserva.GetReservas();
        }
        public Reserva CreateReserva(Reserva reserva, int edificioId)
        {
            IRepositoryReserva _RepositoryReserva = new RepositoryReserva();
            reserva.estado = 0;
            reserva.IDEdificio = edificioId;
            return _RepositoryReserva.Save(reserva);
        }
        public Reserva UpdateState(byte estado, DateTime fecha, int idEdificio)
        {
            IRepositoryReserva _RepositoryReserva = new RepositoryReserva();
            Reserva reserva = _RepositoryReserva.GetReservaByKeys(fecha, idEdificio);
            reserva.estado = estado;
            reserva.Usuario = null;
            reserva.EdificioPublico = null;
            return _RepositoryReserva.Save(reserva);
        }
        public IEnumerable<Reserva> GerReservasByEdificio(int edificioId)
        {
            IRepositoryReserva _RepositoryReserva = new RepositoryReserva();
            return _RepositoryReserva.GetReservas();
        }
    }
}
