using Business.Abstact;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public IResult Add(Blog blog)
        {
            ValidationTool.Validate(new BlogValidator(),blog);
            _blogDal.Add(blog);
            return new SuccessResult(Messages.BlogAdded);
        }

        public IResult Delete(Blog blog)
        {
            _blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll().ToList(),Messages.DataListed);
        }

        public IDataResult<List<BlogTag>> GetBlogTags(int id)
        {
            return new SuccessDataResult<List<BlogTag>>(_blogTagService.GetByBlogId(id).ToList(),Messages.DataListed);
        }

        public IDataResult<List<BlogDetail>> GetBlogDetail(int id)
        {
            return new SuccessDataResult<List<BlogDetail>>(_blogDal.getBlogDetail(b=>b.BlogId==id).ToList(),Messages.DataListed);
        }

        public IResult Update(Blog blog)
        {
            _blogDal.Uptade(blog);
            return new SuccessResult(Messages.BlogUpdated);
        }
    }
}
