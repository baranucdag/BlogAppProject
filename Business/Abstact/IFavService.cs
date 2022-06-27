using Core.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IFavService
    {
        IDataResult<List<Fav>> GetAllFavs();
        IDataResult<List<Fav>> GetAllByBlogId(int blogId);
        IDataResult<List<Fav>> GetAllByUserId(int userId);
        IDataResult<int> GetAllCountByBlogId(int id);
        IResult Delete(Fav fav);
        IResult DeleteById(int blogId, int userId);
        IResult DeleteByBlogId(int blogId);
        IResult Add(Fav fav);
    }
}
