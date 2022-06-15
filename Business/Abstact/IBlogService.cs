using Core.Results;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IBlogService
    {
        IDataResult<List<Blog>> GetAll();
        IDataResult<List<Blog>> GetBlogs(QueryParams queryParams);
        IDataResult<BlogDetailDto> GetBlogDetail(int id);
        IDataResult<List<Blog>> GetBlogsPaginated(int pageNumber, int pageSize);
        IDataResult<List<BlogDetailDto>> GetAllBlogDetails(int pageNumber, int pageSize);
        IDataResult<Blog> GetByBlogId(int id);
        IResult Add(IFormFile file, Blog blog);
        IResult Update(IFormFile file, Blog blog);
        IResult Delete(Blog blog);
    }
}
