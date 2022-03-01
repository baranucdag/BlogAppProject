using Business.Abstact;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BlogTagService : IBlogTagService
    {
        private IBlogTagDal blogTagDal;

        public BlogTagService(IBlogTagDal blogTagDal)
        {
            this.blogTagDal = blogTagDal;
        }
        public void Add(BlogTag blogTag)
        {
            blogTagDal.Add(blogTag);
        }

        public void Delete(BlogTag blogTag)
        {
            blogTagDal.Delete(blogTag);
        }

        public List<BlogTag> GetAll()
        {
            return blogTagDal.GetAll();
        }


        public List<BlogTag> GetByBlogId(int id)
        {
            return blogTagDal.GetAll(b => b.BlogId == id);
        }

        public BlogTag GetByTagId(int id)
        {
            return blogTagDal.Get(b => b.TagId == id);
        }

        public void Update(BlogTag blogTag)
        {
            blogTagDal.Uptade(blogTag);
        }
    }
}
