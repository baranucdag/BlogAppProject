using Business.Abstact;
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
        public void Add(Tag tag)
        {
            tagDal.Add(tag);
        }

        public void Delete(Tag tag)
        {
            tagDal.Delete(tag);
        }

        public List<Tag> GetAll()
        {
            return tagDal.GetAll();
        }

        public Tag GetById(int id)
        {
            return tagDal.Get(t => t.Id == id);
        }

        public void Update(Tag tag)
        {
            tagDal.Uptade(tag);
        }
    }
}
