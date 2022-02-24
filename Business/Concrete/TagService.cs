using Business.Abstact;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TagService : ITagService
    {
        private ITagDal _tagDal;
        public TagService(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }
        public void Add(Tag tag)
        {
            _tagDal.Add(tag);
        }

        public void Delete(Tag tag)
        {
            _tagDal.Delete(tag);
        }

        public List<Tag> GetAll()
        {
            return _tagDal.GetAll().ToList();
        }

        public void Update(Tag tag)
        {
            _tagDal.Uptade(tag);
        }
    }
}
