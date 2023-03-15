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
    public class ServiceRubro : IServiceRubro
    {
        public IEnumerable<Rubro> GetRubros()
        {
            IRepositoryRubro repository = new RepositoryRubro();
            return repository.GetRubros();
        }

        public Rubro GetRubroByID(int id)
        {
            IRepositoryRubro repository = new RepositoryRubro();
            return repository.GetRubroByID(id);
        }

        public Rubro Save(Rubro rubro)
        {
            IRepositoryRubro repository = new RepositoryRubro();
            return repository.Save(rubro);
        }

    }
}
