using Business.Abstact;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CommentService : ICommentService
    {
        ICommentDal _commentDal;
        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public IResult Add(Comment comment)
        {
            _commentDal.Add(comment);
            return new SuccessResult();
        }

        public IResult Delete(Comment comment)
        {
            _commentDal.Delete(comment);
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<Comment> GetByBlogId(int id)
        {
            return new SuccessDataResult<Comment>(_commentDal.Get(c => c.BlogId == id));
        }

        public IResult Update(Comment comment)
        {
            _commentDal.Uptade(comment);
            return new SuccessResult();
        }
    }
}
