using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFBlogTagDal : EFEntityRepositoryBase<BlogTag,DatabaseContext> ,IBlogTagDal
    {
    }
}
