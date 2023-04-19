using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public abstract partial class Edificio
    {

        public string Name
        {
            get
            {
                return string.Format("{0} (Calle {1} Avenida {2})", ID, calle, avenida);
            }
        }

    }
}
