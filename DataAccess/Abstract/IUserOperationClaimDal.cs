using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim> 
    {
        List<UserOperationClaimDto> GetOperationClaimList();
        List<UserOperationClaimDto> GetDetailsById(Expression<Func<UserOperationClaimDto, bool>> filter = null);
    }
}
