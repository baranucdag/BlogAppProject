using Business.Abstact;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CommentService : ICommentService
    {
        ICommentDal commentDal;
        public CommentService(ICommentDal commentDal)
        {
            this.commentDal = commentDal;
        }
        public IResult Add(Comment comment)
        {
            commentDal.Add(comment);
            comment.CreatedTime = System.DateTime.Now;
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            commentDal.Delete(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(commentDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Comment> GetByBlogId(int id)
        {
            return new SuccessDataResult<Comment>(commentDal.Get(x => x.BlogId == id));
        }

        public IDataResult<Comment> GetByCommentId(int id)
        {
            return new SuccessDataResult<Comment>(commentDal.Get(x => x.Id == id));
        }

        public IResult Update(Comment comment)
        {
            commentDal.Uptade(comment);
            return new SuccessResult();
        }
    }
}
