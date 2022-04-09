using Business.Abstact;
using Business.Constans;
using Core.Results;
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
        public IResult Add(BlogTag blogTag)
        {
            blogTagDal.Add(blogTag);
            return new SuccessResult();
        }

        public IResult Delete(BlogTag blogTag)
        {
            blogTagDal.Delete(blogTag);
            return new SuccessResult();
        }

        public IDataResult<List<BlogTag>> GetAll()
        {
            return new SuccessDataResult<List<BlogTag>>(blogTagDal.GetAll(),Messages.DataListed);
        }


        public IDataResult<List<BlogTag>> GetByBlogId(int id)
        {
            return new SuccessDataResult<List<BlogTag>>(blogTagDal.GetAll(x => x.BlogId == id),Messages.DataListed);
        }

        public IDataResult<BlogTag> GetByTagId(int id)
        {
            return new SuccessDataResult<BlogTag>(blogTagDal.Get(x => x.TagId == id),Messages.DataListed);
        }

        public IResult Update(BlogTag blogTag)
        {
            blogTagDal.Uptade(blogTag);
            return new SuccessResult();
        }
    }
}
