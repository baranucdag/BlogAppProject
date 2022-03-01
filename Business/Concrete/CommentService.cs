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
            return new SuccessDataResult<Comment>(commentDal.Get(c => c.BlogId == id));
        }

        public IResult Update(Comment comment)
        {
            commentDal.Uptade(comment);
            return new SuccessResult();
        }
    }
}
