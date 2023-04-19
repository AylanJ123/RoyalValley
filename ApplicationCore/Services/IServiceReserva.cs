using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceReserva
    {
        IEnumerable<Reserva> GetReservas();
        Reserva CreateReserva(Reserva reserva, int edificioID);
        Reserva UpdateState(byte estado, DateTime fecha, int idEdificio);
        IEnumerable<Reserva> GerReservasByEdificio(int edificioId);
    }
}
