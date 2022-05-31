using Business.Abstact;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsClaimsController : ControllerBase
    {
        private IOperationClaimService operationClaimService;
        public OperationsClaimsController(IOperationClaimService operationClaimService)
        {
            this.operationClaimService = operationClaimService;
        }

        [HttpGet("GellAllClaimsPaged")]
        public IActionResult GellAllClaimsPaged(int pageNumber, int pageSize)
        {
            var result = operationClaimService.GetAllCalimsPaged(pageNumber, pageSize);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = operationClaimService.GetAllClaims();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetClaimById")]
        public IActionResult GetClaimById(int id)
        {
            var result = operationClaimService.GetByClaimById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(OperationClaim operationClaim)
        {
            var result = operationClaimService.Add(operationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(OperationClaim operationClaim)
        {
            var result = operationClaimService.Delete(operationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
