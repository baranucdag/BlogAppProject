using Core.Entities.Concrete;
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
        IDataResult<List<OperationClaim>> GetAllCalimsPaged(int pageNumber, int pageSize);
    }
}
