using Business.Abstact;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private ICategoryDal categoryDal;
        public CategoryService(ICategoryDal categoryDal)
        {
            this.categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            categoryDal.Delete(category);
        }

        public List<Category> GetAll()
        {
            return categoryDal.GetAll().ToList();
        }

        public Category GetById(int id)
        {
            return categoryDal.Get(c => c.Id == id);
        }

        public void Update(Category category)
        {
            categoryDal.Uptade(category);
        }
    }
}
