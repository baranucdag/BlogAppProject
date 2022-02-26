using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //BlogService blogService = new BlogService(new EFBlogDal());
            //var results = blogService.GetAll();
            //foreach (var result in results)
            //{
            //    Console.WriteLine(result.CreatedTime);
            //}

            //CategoryService categoryService = new CategoryService(new EFCategoryDal());
            //var result = categoryService.GetById(1);
            //Console.WriteLine(result.GetType());

            //BlogTagService blogTagService = new BlogTagService(new EFBlogTagDal());
            //var result =blogTagService.GetAll();
            //foreach (var tag in result)
            //{
            //    Console.WriteLine(tag.TagId);
            //}

           //BlogService blogService = new BlogService(new EFBlogDal(),new BlogTagService(new EFBlogTagDal()));
           //var result =  blogService.GetBlogTags(9);

           // foreach (var item in result)
           // {
           //     Console.WriteLine(item.TagId);
           // }

            TagService tagService = new TagService(new EFTagDal());
            var result1 = tagService.GetById(3);
            Console.WriteLine(result1.TagName);
           
        }
    }
}
