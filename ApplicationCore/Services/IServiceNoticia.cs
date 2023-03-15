using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceNoticia
    {
        IEnumerable<Noticias> GetNoticias();
        Noticias GetNoticiaByNombre(string nombre);
        Noticias Save(Noticias noticia);
    }
}
