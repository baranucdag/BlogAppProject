using Core.Results;
using Entities.Concrete;
using Entities.Dto;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface ICommentService
    {
        IDataResult<List<Comment>> GetAll();
        IDataResult<List<Comment>> GetByBlogId(int id);
        IDataResult<Comment> GetByCommentId(int id);
        IDataResult<List<CommentDetailDto>> GetCommentDetailsByBlogId(int id);
        IResult Add(Comment comment);
        IResult Update(Comment comment);
        IResult Delete(Comment comment);
        IResult DeleteCommentsByBlogId(int blogId);
        IResult DeleteById(int id);
    }
}
