using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = blogTagService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyblogid")]
        public IActionResult GetByBlogId(int id)
        {
            var result = blogTagService.GetByBlogId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbytagid")]
        public IActionResult GetByTagId(int id)
        {
            var result = blogTagService.GetByTagId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(BlogTag blogTag)
        {
            var result = blogTagService.Add(blogTag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(BlogTag blogTag)
        {
            var result = blogTagService.Update(blogTag);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
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
