using Core.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface ITagService
    {
        IDataResult<List<Tag>> GetAll();
        IDataResult<Tag> GetById(int id);
        IResult Add(Tag tag);
        IResult Update(Tag tag);
        IResult Delete(Tag tag);
    }
}
