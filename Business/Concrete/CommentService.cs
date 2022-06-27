using Business.Abstact;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
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

        public IResult DeleteById(int id)
        {
            commentDal.DeleteByCommentId(id);
            return new SuccessResult();
        }

        public IResult DeleteCommentsByBlogId(int blogId)
        {
            List<Comment> releatedComments = new List<Comment>(commentDal.GetAll(x=>x.BlogId == blogId));
            foreach (var item in releatedComments)
            {
                commentDal.Delete(item);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(commentDal.GetAll(), Messages.DataListed);
        }

        public IDataResult<List<Comment>> GetByBlogId(int id)
        {
            return new SuccessDataResult<List<Comment>>(commentDal.GetAll(x => x.BlogId == id),Messages.DataListed);
        }

        public IDataResult<Comment> GetByCommentId(int id)
        {
            return new SuccessDataResult<Comment>(commentDal.Get(x => x.Id == id));
        }

        public IDataResult<List<CommentDetailDto>> GetCommentDetailsByBlogId(int id)
        {
            return new SuccessDataResult<List<CommentDetailDto>>(commentDal.GetCommentDetail(x=>x.BlogId==id),Messages.DataListed);
        }

        public IResult Update(Comment comment)
        {
            commentDal.Uptade(comment);
            return new SuccessResult();
        }

    }
}
