using Infrastructure.Utils;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceNoticia : IServiceNoticia
    {
        public IEnumerable<Noticias> GetNoticias()
        {
            IRepositoryNoticia repository = new RepositoryNoticia();
            return repository.GetNoticias();
        }

        public Noticias GetNoticiaByNombre(string nombre)
        {
            IRepositoryNoticia repository = new RepositoryNoticia();
            return repository.GetNoticiaByNombre(nombre);
        }

        public Noticias Save(Noticias noticia)
        {
            IRepositoryNoticia repository = new RepositoryNoticia();
            if (noticia.imagen == null) noticia.imagen = new byte[0];
            return repository.Save(noticia);
        }

    }
}
