using Business.Abstact;
using Business.Constans;
using Core.Results;
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

        public IResult Add(Category category)
        {
            categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll().ToList(),Messages.DataListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.Id == id),Messages.DataListed);
        }

        public IResult Update(Category category)
        {
            categoryDal.Uptade(category);
            return new SuccessResult();
        }
    }
}
