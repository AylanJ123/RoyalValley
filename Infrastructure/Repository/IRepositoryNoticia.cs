using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public interface IRepositoryNoticia
    {
        IEnumerable<Noticias> GetNoticias();
        Noticias GetNoticiaByNombre(string nombre);
        Noticias Save(Noticias noticia);
    }
}
