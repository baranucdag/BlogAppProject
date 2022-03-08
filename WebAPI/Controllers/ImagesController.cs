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
        public ImagesController(IImageService ımageService)
        {
            this.imageService = ımageService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Image image)
        {
            var result = imageService.Add(file, image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Image ımage)
        {
            var deletedImage = imageService.GetByImageId(ımage.Id).Data;
            var result = imageService.Delete(deletedImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] Image ımage)
        {
            var result = imageService.Update(file, ımage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyblogid")]
        public IActionResult GetByBlogId(int blogId)
        {
            var result = imageService.GetByBlogId(blogId);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }

        [HttpGet("getbyimageid")]
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
