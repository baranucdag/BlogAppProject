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

            CategoryService categoryService = new CategoryService(new EFCategoryDal());
            var result = categoryService.GetById(1);
            Console.WriteLine(result.GetType());
        }
    }
}
