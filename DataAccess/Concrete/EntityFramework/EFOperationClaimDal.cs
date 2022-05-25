using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFOperationClaimDal :EFEntityRepositoryBase<OperationClaim,DataContext> ,IOperationClaimDal
    {
    }
}
