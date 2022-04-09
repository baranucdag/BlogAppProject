using Core.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IImageService
    {
        IResult Add(IFormFile file, Image image);
        IResult Delete(Image image);
        IResult Update(IFormFile file, Image image);
        IDataResult<List<Image>> GetAll();
        IDataResult<List<Image>> GetByBlogId(int carId);
        IDataResult<Image> GetByImageId(int imageId);
    }
}
