using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagsController : ControllerBase
    {
        private IBlogTagService blogTagService;

        public BlogTagsController(IBlogTagService blogTagService)
        {
            this.blogTagService = blogTagService;   
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = blogTagService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByBlogId")]
        public IActionResult GetByBlogId(int id)
        {
            var result = blogTagService.GetByBlogId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByTagId")]
        public IActionResult GetByTagId(int id)
        {
            var result = blogTagService.GetByTagId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(BlogTag blogTag)
        {
            var result = blogTagService.Add(blogTag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(BlogTag blogTag)
        {
            var result = blogTagService.Update(blogTag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(BlogTag blogTag)
        {
            var result = blogTagService.Delete(blogTag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
