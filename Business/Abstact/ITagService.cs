using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface ITagService
    {
        List<Tag> GetAll();
        Tag GetById(int id);
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(Tag tag);
    }
}
