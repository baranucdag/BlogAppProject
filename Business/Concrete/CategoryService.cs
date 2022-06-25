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
        private IBlogService blogService;
        public CategoryService(ICategoryDal categoryDal,IBlogService blogService)
        {
            this.blogService = blogService;
            this.categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult Delete(Category category)
        {
            if (blogService.GetAll().Data.FirstOrDefault(x=>x.CategoryId==category.Id)!=null)
            {
                return new ErrorResult("There are some relelated data with this category, cannot delete category directly, first delete releated data!");
            }
            categoryDal.Delete(category);
            return new SuccessResult("Category deleted.");
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll().ToList(),Messages.DataListed);
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(categoryDal.Get(x => x.Id == id),Messages.DataListed);
        }

        public IDataResult<List<Category>> GetPaged(int pageNumber, int pageSize)
        {
            return new SuccessDataResult<List<Category>>(categoryDal.GetAll().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList(),Messages.DataListed);
        }

        public IResult Update(Category category)
        {
            categoryDal.Uptade(category);
            return new SuccessResult();
        }
    }
}
