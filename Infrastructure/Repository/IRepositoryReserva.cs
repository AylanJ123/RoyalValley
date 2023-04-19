using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public interface IRepositoryReserva
    {

        IEnumerable<Reserva> GetReservas();
        Reserva Save(Reserva reserva);
        IEnumerable<Reserva> GerReservasByEdificio(int edificioId);
        Reserva GetReservaByKeys(DateTime fecha, int idEdificio);

    }
}
