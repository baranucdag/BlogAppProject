using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstact
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(Category category);
    }
}
