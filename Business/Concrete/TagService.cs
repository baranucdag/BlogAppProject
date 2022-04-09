using Business.Abstact;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class TagService : ITagService
    {
        private ITagDal tagDal;
        public TagService(ITagDal tagDal)
        {
            this.tagDal = tagDal;
        }
        public IResult Add(Tag tag)
        {
            tagDal.Add(tag);
            return new SuccessResult();
        }

        public IResult Delete(Tag tag)
        {
            tagDal.Delete(tag);
            return new SuccessResult();
        }

        public IDataResult<List<Tag>> GetAll()
        {
            return new SuccessDataResult<List<Tag>>(tagDal.GetAll(),Messages.DataListed);
        }

        public IDataResult<Tag> GetById(int id)
        {
            return new SuccessDataResult<Tag>(tagDal.Get(x => x.Id == id),Messages.DataListed);
        }

        public IResult Update(Tag tag)
        {
            tagDal.Uptade(tag);
            return new SuccessResult();
        }
    }
}
