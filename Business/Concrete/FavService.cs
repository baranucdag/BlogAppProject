using Business.Abstact;
using Business.Constans;
using Core.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FavService : IFavService
    {
        private IFavDal favDal;
        public FavService(IFavDal favDal)
        {
            this.favDal = favDal;
        }

        public IDataResult<List<Fav>> GetAllByBlogId(int blogId)
        {
            return new SuccessDataResult<List<Fav>>(favDal.GetAll(x => x.BlogId == blogId));
        }

        public IDataResult<List<Fav>> GetAllByUserId(int userId)
        {
            return new SuccessDataResult<List<Fav>>(favDal.GetAll(x => x.UserId == userId));
        }

        public IDataResult<int> GetAllCountByBlogId(int id)
        {
            return new SuccessDataResult<int>(favDal.GetAll(x => x.BlogId == id).Count, Messages.DataListed);
        }

        public IDataResult<List<Fav>> GetAllFavs()
        {
            return new SuccessDataResult<List<Fav>>(favDal.GetAll());
        }
        public IResult Add(Fav fav)
        {
            fav.CreatedTime = DateTime.Now;
            favDal.Add(fav);
            return new SuccessResult(Messages.FavAdded);
        }

        public IResult Delete(Fav fav)
        {
            favDal.Delete(fav);
            return new SuccessResult(Messages.FavDeleted);
        }

        public IResult DeleteById(int blogId, int userId)
        {
            favDal.DeleteById(blogId, userId);
            return new SuccessResult(Messages.FavDeleted);
        }

        public IResult DeleteByBlogId(int blogId)
        {
            List<Fav> releatedFavs = new List<Fav>(favDal.GetAll(x=>x.BlogId == blogId));
            foreach (var item in releatedFavs)
            {
                favDal.Delete(item);
            }
            return new SuccessResult();
        }
    }
}
