using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public partial class Usuario
    {

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", nombre, apellido1, apellido2);
            }
        }

    }
}
