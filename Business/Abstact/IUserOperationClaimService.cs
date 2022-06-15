using Core.Entities.Concrete;
using Core.Results;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaimDto>> GetAllPaged(int pageNumber, int pageSize);
        IDataResult<List<UserOperationClaimDto>> GetDetailsByUserId(int id);
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
    }
}
