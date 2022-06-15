using Business.Abstact;
using Entities.Concrete;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
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

        [HttpGet("GetAllDetalis")]
        public IActionResult GetAllDetalis(int pageNumber, int pageSize)
        {
            var result = blogService.GetAllBlogDetails(pageNumber,pageSize);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("GetBlogs")]
        public IActionResult GetBlogs([FromQuery] QueryParams queryParams)
        {

            var result = blogService.GetBlogs(queryParams);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Blog blog)
        {
            var result = blogService.Add(file, blog);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] Blog blog)
        {
            var result = blogService.Update(file, blog);
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

        [HttpGet("GetBlogsPaged")]
        public IActionResult GetBlogsPaged(int pageNumber, int pageSize)
        {
            var result = blogService.GetBlogsPaginated(pageNumber, pageSize);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
