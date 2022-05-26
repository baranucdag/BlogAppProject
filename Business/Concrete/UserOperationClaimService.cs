using Business.Abstact;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Helpers.PaginationHelper;
using Core.Results;
using DataAccess.Abstract;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserOperationClaimService : IUserOperationClaimService
    {
        private IUserOperationClaimDal userOperationClaimDal;
        public UserOperationClaimService(IUserOperationClaimDal userOperationClaimDal)
        {
            this.userOperationClaimDal = userOperationClaimDal;
        }
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult();
        }

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult();
        }

        public PaginationHelper<UserOperationClaimDto> GetAllDetails(int pageNumber, int pageSize)
        {
            return PaginationHelper<UserOperationClaimDto>.ToPagedList(userOperationClaimDal.GetOperationClaimList(), pageNumber, pageSize);
        }

        public IDataResult<List<UserOperationClaimDto>> GetDetailsByUserId(int id)
        {
            return new SuccessDataResult<List<UserOperationClaimDto>>(userOperationClaimDal.GetDetailsById(x => x.UserId == id), Messages.DataListed);
        }

        public IResult Update(UserOperationClaim userOperationClaim)
        {
            userOperationClaimDal.Uptade(userOperationClaim);
            return new SuccessResult();
        }
    }
}
