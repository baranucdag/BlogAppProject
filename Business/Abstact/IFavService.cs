using Core.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IResult Add(Fav fav);
    }
}
