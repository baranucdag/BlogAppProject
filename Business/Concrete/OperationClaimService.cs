using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Results;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class OperationClaimService : IOperationClaimService
    {
        private IOperationClaimDal operationClaimDal;
        public OperationClaimService(IOperationClaimDal operationClaimDal)
        {
            this.operationClaimDal = operationClaimDal;
        }

        public IResult Add(OperationClaim operationClaim)
        {
            operationClaimDal.Add(operationClaim);
            return new SuccessResult();
        }

        public IResult Delete(OperationClaim operationClaim)
        {
            operationClaimDal.Delete(operationClaim);
            return new SuccessResult();
        }

        public IDataResult<List<OperationClaim>> GetAllClaims()
        {
            return new SuccessDataResult<List<OperationClaim>>(operationClaimDal.GetAll(), Messages.DataListed);
        }
        public IDataResult<List<OperationClaim>> GetAllCalimsPaged(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<OperationClaim>>(operationClaimDal.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(), Messages.DataListed);
        }

        public IDataResult<OperationClaim> GetByClaimById(int id)
        {
            return new SuccessDataResult<OperationClaim>(operationClaimDal.Get(x => x.Id == id), Messages.DataListed);
        }
    }
}
