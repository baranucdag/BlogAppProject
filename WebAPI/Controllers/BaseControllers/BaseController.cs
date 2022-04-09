using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

    }
}


//todo:base conrtoller yapısı nasıl olmalıdır.
//todo:register güncellendi
//todo: create password hash de zaten öncesinde dto check ediliyor dolayısıyla birdaha check etmeye gerek yok