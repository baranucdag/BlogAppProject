using Business.Abstact;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogTagService : IBlogTagService
    {
        private IBlogTagDal _blogTagDal;
      
        public BlogTagService(IBlogTagDal blogTagDal)
        {
            _blogTagDal = blogTagDal;
        }
        public void Add(BlogTag blogTag)
        {
            _blogTagDal.Add(blogTag);   
        }

        public void Delete(BlogTag blogTag)
        {
            _blogTagDal.Delete(blogTag);
        }

        public List<BlogTag> GetAll()
        {
            return _blogTagDal.GetAll();
        }

        public List<BlogTag> GetByBlogId(int id)
        {
            return _blogTagDal.GetAll(b=>b.BlogId==id);
        }

        public BlogTag GetByTagId(int id)
        {
            return _blogTagDal.Get(b => b.TagId == id);
        }

        public void Update(BlogTag blogTag)
        {
            _blogTagDal.Uptade(blogTag);
        }
    }
}
