using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private IBlogService blogService;
        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }



        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = blogService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Blog blog)
        {
            var result = blogService.Add(blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Blog blog)
        {
            var result = blogService.Update(blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Blog blog)
        {
            var result = blogService.Delete(blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBlogDetails")]
        public IActionResult GetBlogDetails(int id)
        {
            var result = blogService.GetBlogDetail(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetBlogById")]
        public IActionResult GetByBlogById(int id)
        {
            var result = blogService.GetByBlogId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
