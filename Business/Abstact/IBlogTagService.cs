using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
