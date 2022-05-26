using Core.Entities.Concrete;
using Core.Helpers.PaginationHelper;
using Core.Results;

namespace Business.Abstact
{
    public interface IOperationClaimService
    {
        IResult Add(OperationClaim operationClaim);
        IResult Delete(OperationClaim operationClaim);
        IDataResult<OperationClaim> GetByClaimById(int id);
        PaginationHelper<OperationClaim> GetAllCalimsPaged(int pageNumber, int pageSize);
    }
}
