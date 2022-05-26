using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFUserOperationClaimDal : EFEntityRepositoryBase<UserOperationClaim, DataContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetOperationClaimList()
        {
            using (var context = new DataContext())
            {
                var result = from t1 in context.UserOperationClaims
                             join t2 in context.Users
                             on t1.UserId equals t2.Id

                             join t3 in context.OperationClaims
                             on t1.OperationClaimId equals t3.Id

                             select new UserOperationClaimDto
                             {
                                 Id = t1.Id,
                                 UserId = t2.Id,
                                 Email = t2.Email,
                                 FirstName = t2.FirstName,
                                 LastName = t2.LastName,
                                 OperationClaimId = t3.Id,
                                 ClaimName = t3.Name,

                             };
                return result.ToList();
            }
        }

        public List<UserOperationClaimDto> GetDetailsById(Expression<Func<UserOperationClaimDto, bool>> filter = null)
        {
            using (var context = new DataContext())
            {
                var result = from t1 in context.UserOperationClaims
                             join t2 in context.Users
                             on t1.UserId equals t2.Id

                             join t3 in context.OperationClaims
                             on t1.OperationClaimId equals t3.Id

                             select new UserOperationClaimDto
                             {
                                 Id = t1.Id,
                                 UserId = t2.Id,
                                 Email = t2.Email,
                                 FirstName = t2.FirstName,
                                 LastName = t2.LastName,
                                 OperationClaimId = t3.Id,
                                 ClaimName = t3.Name,

                             };
               return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
