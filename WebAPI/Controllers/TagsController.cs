using Business.Abstact;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private ITagService tagsService;
        public TagsController(ITagService tagService)
        {
            this.tagsService = tagService;  
        }
            
    }
}
