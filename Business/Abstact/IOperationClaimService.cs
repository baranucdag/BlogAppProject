using Core.Entities.Concrete;
using Core.Helpers.PaginationHelper;
using Core.Results;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IDataResult<OperationClaim> GetByClaimById(int id);
        IDataResult<List<OperationClaim>> GetAllClaims();
        PaginationHelper<OperationClaim> GetAllCalimsPaged(int pageNumber, int pageSize);
    }
}
