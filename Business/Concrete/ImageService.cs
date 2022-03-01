using Business.Abstact;
using Core.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : IImageService
    {
        IImageDal imageDal;
        public CarImageManager(IImageDal imageDal)
        {
            this.imageDal = imageDal;
        }

        public IResult Add(IFormFile formFile, Image ımage)
        {
            var ımageCount = imageDal.GetAll().Count;
            if (ımageCount >= 1)
            {
                return new ErrorResult("A blog must have only 1 image");
            }

            var imageResult = FileHelper.Upload(formFile);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            ımage.ImagePath = imageResult.Message;
            imageDal.Add(ımage);
            return new SuccessResult("Blog image added.");
        }

        public IResult Delete(Image ımage)
        {
            var image = imageDal.Get(c => c.BlogId == ımage.BlogId);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(image.ImagePath);
            imageDal.Delete(ımage);
            return new SuccessResult("Image deleted successfully");
        }

        public IResult Update(IFormFile file, Image ımage)
        {
            var isImage = imageDal.Get(c => c.BlogId == ımage.BlogId);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }

            var updatedFile = FileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            ımage.ImagePath = updatedFile.Message;
            imageDal.Uptade(ımage);
            return new SuccessResult("Blog image updated");
        }
        public IDataResult<Image> Get(int id)
        {
            return new SuccessDataResult<Image>(imageDal.Get(p => p.BlogId == id));
        }
        public IDataResult<List<Image>> GetAll()
        {
            return new SuccessDataResult<List<Image>>(imageDal.GetAll());
        }

        public IDataResult<List<Image>> GetImagesByBlogId(int id)
        {
            return new SuccessDataResult<List<Image>>(CheckIfBlogImageNull(id).Data);
        }


        //business rules
        private IResult CheckImageLimitExceeded(int blogId)
        {
            var carImagecount = imageDal.GetAll(p => p.BlogId == blogId).Count;
            if (carImagecount >= 1)
            {
                return new ErrorResult("Blog image limit exceeded");
            }

            return new SuccessResult();
        }

        private IDataResult<List<Image>> CheckIfBlogImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = imageDal.GetAll(c => c.BlogId == id).Any();
                if (!result)
                {
                    List<Image> carimage = new List<Image>();
                    carimage.Add(new Image { BlogId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<Image>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<Image>>(exception.Message);
            }

            return new SuccessDataResult<List<Image>>(imageDal.GetAll(p => p.BlogId == id).ToList());
        }
        private IResult BlogImageDelete(Image ımage)
        {
            try
            {
                FileHelper.Delete(ımage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
