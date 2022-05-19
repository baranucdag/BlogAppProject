using Business.Abstact;
using Business.BusinessAspects.Autofac;
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


        [SecuredOperation("admin,blog.add")]
        //[ValidationAspect(typeof(BlogValidator))]
        public IResult Add(Blog blog)
        {
            //ValidationTool.Validate(new BlogValidator(), blog);
            // SecuredOperationTool securedOperation = new SecuredOperationTool("admin");

            blogDal.Add(blog);
            blog.CreatedAt = System.DateTime.Now;
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
            return new SuccessDataResult<List<Blog>>(blogDal.GetAll().OrderBy(x => x.Id).ToList(), Messages.DataListed);
        }

        //create only one method by using QueryParamsDto (props )
        //get all Blogs paged by cursor pagination

        public IDataResult<List<Blog>> GetBlogs(QueryParams queryParams)
        {
            // total count konnrtolünü sağla
            if (queryParams.SortType == false)
            {
                if (string.IsNullOrEmpty(queryParams.QueryString)) return new SuccessDataResult<List<Blog>>(blogDal.GetAll().Take(queryParams.Count).ToList(), Messages.DataListed);
                return new SuccessDataResult<List<Blog>>(blogDal.GetAll(x => x.BlogContent.Contains(queryParams.QueryString)
                || x.BlogTitle.Contains(queryParams.QueryString)).Take(queryParams.Count).ToList(), Messages.DataListed);
            }
            else
            {
                if (string.IsNullOrEmpty(queryParams.QueryString)) return new SuccessDataResult<List<Blog>>(blogDal.GetAll().OrderByDescending(x => x.Id).Take(queryParams.Count).ToList(), Messages.DataListed);
                return new SuccessDataResult<List<Blog>>(blogDal.GetAll(x => x.BlogContent.Contains(queryParams.QueryString)
                || x.BlogTitle.Contains(queryParams.QueryString)).OrderByDescending(x => x.Id).Take(queryParams.Count).ToList(), Messages.DataListed);
            }

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
