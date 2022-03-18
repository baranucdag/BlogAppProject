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

            //TagService tagService = new TagService(new EFTagDal());
            //var result1 = tagService.GetById(3);
            //Console.WriteLine(result1.TagName);

            //BlogTagService blogTagService = new BlogTagService(new EFBlogTagDal());
            //var result = blogTagService.GetByTagId(1);
            //Console.WriteLine(result.BlogId);


            //double[] array = new double[5] ;
            //for (int i = 0; i < array.Length; i++)
            //{
            //    var input = Convert.ToInt32((Console.ReadLine()));
            //    array[i] = input;
            //}
            //foreach (var item in array)
            //{
            //    Console.WriteLine(item);
            //}

            //    char startPeg = 'A'; // start tower in output   
            //    char endPeg = 'C'; // end tower in output
            //    char tempPeg = 'B'; // temporary tower in output
            //    int totalDisks = 5; // number of disks

            //    solveTowers(totalDisks, startPeg, endPeg, tempPeg);
            //}

            //private static void solveTowers(int n, char startPeg, char endPeg, char tempPeg)
            //{
            //    if (n > 0)
            //    {
            //        solveTowers(n - 1, startPeg, tempPeg, endPeg);
            //        Console.WriteLine("Move disk from " + startPeg + ' ' + endPeg);
            //        solveTowers(n - 1, tempPeg, endPeg, startPeg);

            //    }
           

        }

    }
}
