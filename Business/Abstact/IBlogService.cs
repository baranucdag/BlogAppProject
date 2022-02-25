using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        List<BlogDetail> GetCategories();
        List<BlogTag> GetBlogTags(int id);
        void Add(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);

    }
}
