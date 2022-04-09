using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFBlogDal : EFEntityRepositoryBase<Blog, DataContext>, IBlogDal
    {
        public BlogDetailDto getBlogDetail(Expression<Func<BlogDetailDto, bool>> filter = null)
        {
            using (var context = new DataContext())
            {
                var result = from t1 in context.Blogs
                             join t2 in context.Categories
                             on t1.CategoryId equals t2.Id
                             join t3 in context.Users
                             on t1.UserId equals t3.Id
                             select new BlogDetailDto()
                             {
                                 BlogId = t1.Id,
                                 BlogContent = t1.BlogContent,
                                 BlogTitle = t1.BlogTitle,
                                 CategoryName = t2.CategoryName,
                                 Email = t3.Email,
                                 CreatedAt = t1.CreatedTime

                             };
                return filter == null ? result.FirstOrDefault() : result.Where(filter).FirstOrDefault();


            }
        }
    }
}
