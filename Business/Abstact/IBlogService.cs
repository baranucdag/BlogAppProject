using Business.Concrete;
using Core.Helpers.PaginationHelper;
using Core.Results;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetBlogs(QueryParams queryParams);
        IDataResult<BlogDetailDto> GetBlogDetail(int id);
        PaginationHelper<Blog> GetBlogsPaginated(int pageNumber, int pageSize);
        IDataResult<List<BlogTag>> GetBlogTags(int id);
        IDataResult<Blog> GetByBlogId(int id);
        IResult Add(Blog blog);
        IResult Update(Blog blog);
        IResult Delete(Blog blog);
    }
}
