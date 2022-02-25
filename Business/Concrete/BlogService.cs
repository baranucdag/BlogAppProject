using Business.Abstact;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogService : IBlogService
    {
        private IBlogDal _blogDal;
        private IBlogTagService _blogTagService;
        public BlogService(IBlogDal blogDal, IBlogTagService blogTagService)
        {
            _blogDal = blogDal;
            _blogTagService = blogTagService;
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll().ToList();
        }

        public List<BlogTag> GetBlogTags(int id)
        {
            return _blogTagService.GetByBlogId(id);
        }

        public List<BlogDetail> GetBlogDetail(int id)
        {
            return _blogDal.getBlogDetail(b=>b.BlogId==id);
        }

        public void Update(Blog blog)
        {
            _blogDal.Uptade(blog);
        }
    }
}
