using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFImageDal : EFEntityRepositoryBase<Image, DataContext>, IImageDal
    {
        public void DeleteByImagePath(string imagePath)
        {

            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Images.FirstOrDefault(x => x.ImagePath == imagePath);
                context.Remove(deletedEntity);
                context.SaveChanges();
            }
        }
    }
}
