using Business.Abstact;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavsController : ControllerBase
    {
        private IFavService favService;
        public FavsController(IFavService favService)
        {
            this.favService = favService;   
        }

        //get all favs (without parametr)
        [HttpGet("GetAllFavs")]
        public IActionResult GetAllFavs()
        {
            var result = favService.GetAllFavs();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        //get all favs by blog id
        [HttpGet("GetAllByBlogId")]
        public IActionResult GetAllByBlogId(int blogId)
        {
            var result = favService.GetAllByBlogId(blogId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //get all favs by user id
        [HttpGet("GetAllByUserId")]
        public IActionResult GetAllByUserId(int userId)
        {
            var result = favService.GetAllByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //get fav count by blog id
        [HttpGet("GetFavCount")]
        public IActionResult GetFavCountByBlogId(int id)
        {
            var result = favService.GetAllCountByBlogId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //add fav
        [HttpPost("Add")]
        public IActionResult Add(Fav fav)
        {
            var result = favService.Add(fav);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //delete fav
        [HttpPost("Delete")]
        public IActionResult Delete(Fav fav)
        {
            var result = favService.Delete(fav);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //delete by fav user id and blog id
        [HttpPost("DeleteById")]
        public IActionResult Delete(int blogId,int userId)
        {
            var result = favService.DeleteById(blogId,userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
