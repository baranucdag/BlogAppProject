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

        //    char baslngicStun = 'A'; // başlangıç sütunu   
        //    char sonucSutun = 'C'; // sonuç sütunu
        //    char geciciStun = 'B'; //geçici olarak disklerin tutulacağı sütun
        //    int totalDisk = 3; // totaldeki disk sayısı (N sayıda olabilir)

        //    CozumFonk(totalDisk, baslngicStun, sonucSutun, geciciStun);
        //}

        //private static void CozumFonk(int n, char baslngicStun, char sonucSutun, char geciciStun)
        //{
        //    if (n > 0)
        //    {
        //        CozumFonk(n - 1, baslngicStun, geciciStun, sonucSutun);  
        //        Console.WriteLine("diski " + baslngicStun + " dan" + ' ' + sonucSutun + " 'ye taşı");
        //        CozumFonk(n - 1, geciciStun, sonucSutun, baslngicStun);

        //    }




            //char[] char_array = { 'A', 'B', 'C', 'D', 'E' };
            //Console.WriteLine("ORİJİNAL DİZİ : ");
            //for (int k = 0; k < char_array.Length; k++)
            //{
            //    Console.WriteLine(char_array[k] + " ");
            //}
            //Console.WriteLine();
            //reverse_array(char_array, char_array.Length);
        }
        //public static void reverse_array(char[] char_array, int n)
        //{
        //    char[] dest_array = new char[n];
        //    int j = n;
        //    for (int i = 0; i < n; i++)
        //    {
        //        dest_array[j - 1] = char_array[i];
        //        j = j - 1;
        //    }

        //    Console.WriteLine("ÇEVİRİLMİŞ DİZİ");
        //    for (int k = 0; k < n; k++)
        //    {
        //        Console.WriteLine(dest_array[k] + " ");
        //    }

        //}
    }
}
