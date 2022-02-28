using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IBlogTagService
    {
        List<BlogTag> GetAll();
        List<BlogTag> GetByBlogId(int id);
        BlogTag GetByTagId(int id);
        void Add(BlogTag blogTag);
        void Update(BlogTag blogTag);
        void Delete(BlogTag blogTag);
    }
}
