using Business.Abstact;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        private IUserOperationClaimService userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            this.userOperationClaimService = userOperationClaimService; 
        }

        [HttpGet("GetAllDetails")]
        public IActionResult GetAllDetails(int pageNumber,int pageSize)
        {
            var result = userOperationClaimService.GetAllPaged(pageNumber, pageSize);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetDetailsByUserId")]
        public IActionResult GetDetailsByUserId(int id)
        {
            var result = userOperationClaimService.GetDetailsByUserId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            var result = userOperationClaimService.Add(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            var result = userOperationClaimService.Update(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = userOperationClaimService.Delete(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
