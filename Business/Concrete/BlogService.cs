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
    public class BlogService : IBlogService
    {
        private IBlogDal _blogDal;
        public BlogService(IBlogDal blogDal)
        {
            _blogDal = blogDal; 
        }

        public void Add(Blog blog)
        {
            _blogDal.Add(blog);
        }

        public void Delete(Blog blog)
        {
            _blogDal.Delete(blog);
        }

        public Blog Get()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll().ToList();
        }

        public void Update(Blog blog)
        {
            _blogDal.Uptade(blog);
        }
    }
}
