using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>
    {
        BlogDetailDto getBlogDetail(Expression<Func<BlogDetailDto, bool>> filter = null);
    }
}
