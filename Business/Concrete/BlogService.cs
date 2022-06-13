﻿using Business.Abstact;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects;
using Core.CrossCuttingConcerns.Validation;
using Core.Helpers;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class BlogService : IBlogService
    {
        private IBlogDal blogDal;
        private IFileHelper fileHelper;
        public BlogService(IBlogDal blogDal, IFileHelper fileHelper)
        {
            this.blogDal = blogDal;
            this.fileHelper = fileHelper;
        }

        [SecuredOperation("admin,blog.add")]
        [ValidationAspect(typeof(BlogValidator))]
        public IResult Add(IFormFile file, Blog blog)
        {
            //ValidationTool.Validate(new BlogValidator(), blog);
            // SecuredOperationTool securedOperation = new SecuredOperationTool("admin");
            blog.CreatedAt = System.DateTime.Now;
            blog.ImagePath = fileHelper.Upload(file, PathConstants.ImagesPath);
            blogDal.Add(blog);
            return new SuccessResult("blog added");
        }

        public IResult Delete(Blog blog)
        {
            fileHelper.Delete(blog.ImagePath);
            blogDal.Delete(blog);
            return new SuccessResult(Messages.BlogDeleted);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(blogDal.GetAll().OrderBy(x => x.Id).ToList(), Messages.DataListed);
        }

        //get blogs paged (by using pagination helper)
        public IDataResult<List<Blog>> GetBlogsPaginated(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<Blog>>(blogDal.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), Messages.DataListed);
        }


        public IDataResult<List<Blog>> GetBlogs(QueryParams queryParams)
        {
            // check total count of data (to hide 'see more blog' button)
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

        public IDataResult<BlogDetailDto> GetBlogDetail(int id)
        {
            return new SuccessDataResult<BlogDetailDto>(blogDal.getBlogDetail(x => x.BlogId == id), Messages.DataListed);
        }

        public IResult Update(IFormFile file, Blog blog)
        {
            if (file != null)
            {
                blog.ImagePath = fileHelper.Update(file, PathConstants.ImagesPath + blog.ImagePath, PathConstants.ImagesPath);
            }
            blog.CreatedAt = System.DateTime.Now;
            blogDal.Uptade(blog);
            ValidationTool.Validate(new BlogValidator(), blog);
            return new SuccessResult(Messages.BlogUpdated);
        }

        public IDataResult<Blog> GetByBlogId(int id)
        {
            return new SuccessDataResult<Blog>(blogDal.Get(x => x.Id == id), Messages.DataListed);
        }

        public IDataResult<List<BlogDetailDto>> GetAllBlogDetails()
        {
            return new SuccessDataResult<List<BlogDetailDto>>(blogDal.GetAllBlogDetails(), Messages.DataListed);
        }

    }
}
