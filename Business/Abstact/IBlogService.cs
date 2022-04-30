using Business.Concrete;
using Core.Results;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> Get(BlogQueryOptions queryOptions);
        IDataResult<List<Blog>> GetAll();
        IDataResult<BlogDetailDto> GetBlogDetail(int id);
        IDataResult<List<BlogTag>> GetBlogTags(int id);
        IDataResult<Blog> GetByBlogId(int id);
        IResult Add(Blog blog);
        IResult Update(Blog blog);
        IResult Delete(Blog blog);
    }
}
