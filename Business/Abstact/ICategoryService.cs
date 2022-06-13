using Core.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int id);
        IResult Add(Category category);
        IDataResult<List<Category>> GetPaged(int pageNumber, int pageSize);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
