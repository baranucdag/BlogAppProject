using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCommentDal : EFEntityRepositoryBase<Comment, DataContext>, ICommentDal
    {
        public void DeleteByCommentId(int id)
        {
            using (DataContext context = new DataContext())
            {
                var deletedEntity = context.Comments.First(x => x.Id==id);
                context.Remove(deletedEntity);
                context.SaveChanges();
            }
        }

        public List<CommentDetailDto> GetCommentDetail(Expression<Func<CommentDetailDto, bool>> filter = null)
        {
            using (var context = new DataContext())
            {
                var result = from t1 in context.Comments
                             join t2 in context.Users
                             on t1.UserId equals t2.Id
                             select new CommentDetailDto()
                             {
                                 CommentId = t1.Id,
                                 BlogId = t1.BlogId,
                                 UserEmail = t2.Email,
                                 UserId = t2.Id,
                                 CommentContent = t1.CommentContent,
                                 CreatedTime = t1.CreatedTime

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}
