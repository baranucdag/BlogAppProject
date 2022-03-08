using Business.Abstact;
using Business.Constans;
using Core.Helpers;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ImageService : IImageService
    {
        private IImageDal imageDal;
        private IFileHelper fileHelper;

        public ImageService(IImageDal imageDal, IFileHelper fileHelper)
        {
            this.imageDal = imageDal;
            this.fileHelper = fileHelper;
        }

        // adding an ımage 
        public IResult Add(IFormFile file, Image ımage)
        {

            ımage.ImagePath = fileHelper.Upload(file, PathConstants.ImagesPath);
            ımage.Date = DateTime.Now;
            imageDal.Add(ımage);
            return new SuccessResult("Image added successfully");
        }

        // delete an ımage
        public IResult Delete(Image ımage)
        {
            fileHelper.Delete(PathConstants.ImagesPath + ımage.ImagePath);
            imageDal.Delete(ımage);
            return new SuccessResult();
        }

        // update an ımage
        public IResult Update(IFormFile file, Image ımage)
        {
            ımage.ImagePath = fileHelper.Update(file, PathConstants.ImagesPath + ımage.ImagePath, PathConstants.ImagesPath);
            imageDal.Uptade(ımage);
            return new SuccessResult();
        }

        // returns all BlogImages
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(imageDal.GetAll());
        }

        // returns an ımage by blogId
        public IDataResult<List<Image>> GetByBlogId(int blogId)
        {
            var result = CheckBlogImage(blogId);
            if (result.Success)
            {
                return new ErrorDataResult<List<Image>>(GetDefaultImage(blogId).Data);
            }

            return new SuccessDataResult<List<Image>>(imageDal.GetAll(x => x.BlogId == blogId));
        }

        //returns an ımage by ımageId
        public IDataResult<Image> GetByImageId(int imageId)
        {
            return new SuccessDataResult<Image>(imageDal.Get(x => x.Id == imageId));
        }


        // checks if any ımage exist by blogId
        private IResult CheckBlogImage(int blogId)
        {
            var result = imageDal.GetAll(x => x.BlogId == blogId).Count;
            return result > 0 ? new SuccessResult() : new ErrorResult();
           
        }

        // returns default ımage by blogId
        private IDataResult<List<Image>> GetDefaultImage(int blogId)
        {

            List<Image> ımage = new List<Image>();
            ımage.Add(new Image { BlogId = blogId, Date = DateTime.Now, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<Image>>(ımage);
        }

    }
}
