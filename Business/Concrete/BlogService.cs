using Business.Abstact;
using Business.BusinessAspects;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.CrossCuttingConcerns.SecuredOperation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
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


        //[SecuredOperation("admin")]
        //[ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            //ValidationTool.Validate(new BlogValidator(), blog);
           // SecuredOperationTool securedOperation = new SecuredOperationTool("admin");

            blogDal.Add(blog);
            blog.CreatedTime = System.DateTime.Now;
            return new SuccessResult(Messages.BlogAdded);
        }

        //[SecuredOperation("blog.delete")]
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

        public IDataResult<BlogDetailDto> GetBlogDetail(int id)
        {
            return new SuccessDataResult<BlogDetailDto>(blogDal.getBlogDetail(x => x.BlogId == id), Messages.DataListed);
        }

        public IResult Update(Blog blog)
        {
            ValidationTool.Validate(new BlogValidator(), blog);
            blogDal.Uptade(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }

        public IDataResult<Blog> GetByBlogId(int id)
        {
            return new SuccessDataResult<Blog>(blogDal.Get(x => x.Id == id), Messages.DataListed);
        }
    }
}
