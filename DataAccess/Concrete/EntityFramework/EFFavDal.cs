using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFFavDal : EFEntityRepositoryBase<Fav, DataContext>, IFavDal
    {
        public void DeleteById(int id)
        {
            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Favs.First(x => x.Id == id);
                context.Remove(deletedEntity);
                context.SaveChanges();
            }
        }
    }
}
