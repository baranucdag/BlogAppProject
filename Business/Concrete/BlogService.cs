using Business.Abstact;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BlogService : IBlogService
    {
        private IBlogDal blogDal;
        private IBlogTagService blogTagService;
        public BlogService(IBlogDal blogDal, IBlogTagService blogTagService)
        {
            this.blogDal = blogDal;
            this.blogTagService = blogTagService;
        }

        public IResult Add(Blog blog)
        {
            ValidationTool.Validate(new BlogValidator(), blog);
            blogDal.Add(blog);
            blog.CreatedTime = System.DateTime.Now;
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(blogDal.GetAll().ToList(), Messages.DataListed);
        }

        public IDataResult<List<BlogTag>> GetBlogTags(int id)
        {
            return new SuccessDataResult<List<BlogTag>>(blogTagService.GetByBlogId(id).Data, Messages.DataListed);
        }

        public IDataResult<List<BlogDetailDto>> GetBlogDetail(int id)
        {
            return new SuccessDataResult<List<BlogDetailDto>>(blogDal.getBlogDetail(b => b.BlogId == id).ToList(), Messages.DataListed);
        }

        public IResult Update(Blog blog)
        {
            blogDal.Uptade(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }
    }
}
