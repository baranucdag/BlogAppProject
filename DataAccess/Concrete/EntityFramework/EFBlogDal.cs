using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFBlogDal : EFEntityRepositoryBase<Blog,DatabaseContext> ,IBlogDal
    {
        public List<BlogDetail> getBlogDetail(Expression<Func<BlogDetail, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                var result = from b in context.Blogs
                             join c in context.Categories
                             on b.CategoryId equals c.Id
                             select new BlogDetail()
                             {
                                 BlogId = b.Id,
                                 BlogContent = b.BlogContent,
                                 BlogTitle = b.BlogTitle,
                                 CategoryName = c.CategoryName
                                 
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
