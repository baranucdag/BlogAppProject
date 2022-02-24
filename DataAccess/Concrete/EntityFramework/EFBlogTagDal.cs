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
    public class EFBlogTagDal : EFEntityRepositoryBase<BlogTag, DatabaseContext>, IBlogTagDal
    {
        public List<BlogTagDetail> getBlogDetail(Expression<Func<BlogTagDetail, bool>> filter = null)
        {
            using (var context = new DatabaseContext())
            {
                var result = from bt in context.BlogTags
                             join b in context.Blogs
                             on bt.BlogId equals b.Id
                             join t in context.Tags
                             on bt.TagId equals t.Id
                             select new BlogTagDetail()
                             {
                                 BlogId = b.Id,
                                 TagId = t.Id,
                                 BlogTitle = b.BlogTitle,
                                 TagName = t.TagName
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
