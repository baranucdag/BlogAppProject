using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private IImageService imageService;
        public ImagesController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Image image)
        {
            var result = imageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Image image)
        {
            var deletedImage = imageService.GetByImageId(image.Id).Data;
            var result = imageService.Delete(deletedImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image image)
        {
            var result = imageService.Update(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByBlogId")]
        public IActionResult GetByBlogId(int blogId)
        {
            var result = imageService.GetByBlogId(blogId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpGet("GetByImageId")]
        public IActionResult GetByImageId(int imageId)
        {
            var result = imageService.GetByImageId(imageId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
