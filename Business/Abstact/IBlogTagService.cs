using Core.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IBlogTagService
    {
        IDataResult<List<BlogTag>> GetAll();
        IDataResult<List<BlogTag>> GetByBlogId(int id);
        IDataResult<BlogTag> GetByTagId(int id);
        IResult Add(BlogTag blogTag);
        IResult Update(BlogTag blogTag);
        IResult Delete(BlogTag blogTag);
    }
}
