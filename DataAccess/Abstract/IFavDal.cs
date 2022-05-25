using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IFavDal  : IEntityRepository<Fav>
    {
        void DeleteById(int blogId, int userId);
    }
}
