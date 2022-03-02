using Business.Abstact;
using Business.Constans;
using Core.Helpers;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ImageService : IImageService
    {
        private IImageDal ımageDal;
        private IFileHelper fileHelper;

        public ImageService(IImageDal ımageDal, IFileHelper fileHelper)
        {
            this.ımageDal = ımageDal;
            this.fileHelper = fileHelper;
        }

        // adding an ımage 
        public IResult Add(IFormFile file, Image ımage)
        {

            ımage.ImagePath = fileHelper.Upload(file, PathConstants.ImagesPath);
            ımage.Date = DateTime.Now;
            ımageDal.Add(ımage);
            return new SuccessResult("Image added successfully");
        }

        // delete an ımage
        public IResult Delete(Image ımage)
        {
            fileHelper.Delete(PathConstants.ImagesPath + ımage.ImagePath);
            ımageDal.Delete(ımage);
            return new SuccessResult();
        }

        // update an ımage
        public IResult Update(IFormFile file, Image ımage)
        {
            ımage.ImagePath = fileHelper.Update(file, PathConstants.ImagesPath + ımage.ImagePath, PathConstants.ImagesPath);
            ımageDal.Uptade(ımage);
            return new SuccessResult();
        }

        // returns all BlogImages
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(ımageDal.GetAll());
        }

        // returns an ımage by blogId
        public IDataResult<List<Image>> GetByBlogId(int blogId)
        {
            var result = CheckBlogImage(blogId);
            if (result.Success)
            {
                return new ErrorDataResult<List<Image>>(GetDefaultImage(blogId).Data);
            }

            return new SuccessDataResult<List<Image>>(ımageDal.GetAll(x => x.BlogId == blogId));
        }

        //returns an ımage by ımageId
        public IDataResult<Image> GetByImageId(int imageId)
        {
            return new SuccessDataResult<Image>(ımageDal.Get(x => x.Id == imageId));
        }


        // checks if any ımage exist by blogID
        private IResult CheckBlogImage(int blogId)
        {
            var result = ımageDal.GetAll(x => x.BlogId == blogId).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
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
