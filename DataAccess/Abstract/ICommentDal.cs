using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        List<CommentDetailDto> GetCommentDetail(Expression<Func<CommentDetailDto, bool>> filter = null);
        void DeleteByCommentId(int id);
    }
}
