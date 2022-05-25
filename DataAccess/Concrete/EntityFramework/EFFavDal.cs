using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFFavDal : EFEntityRepositoryBase<Fav, DataContext>, IFavDal
    {
        public void DeleteById(int blogId, int userId)
        {
            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Favs.First(x => x.BlogId==blogId && x.UserId==userId);
                context.Remove(deletedEntity);
                context.SaveChanges();
            }
        }
    }
}
