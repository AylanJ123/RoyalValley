using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.DTOS
{
    public class EstadoCuenta
    {
        public Residencia Residencia { get; private set; }
        public List<Cobro> Cobros { get; private set; }

        public EstadoCuenta(List<Cobro> cobros)
        {
            if (cobros.Count == 0) throw new Exception("No puede existir un estado de cuenta si no se ha generado ni un solo cobro");
            Residencia = cobros.First().Residencia;
            Cobros = cobros;
        }

    }
}
