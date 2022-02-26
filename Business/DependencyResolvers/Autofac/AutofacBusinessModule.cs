using Autofac;
using Business.Abstact;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogService>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EFBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<BlogTagService>().As<IBlogTagService>().SingleInstance();
            builder.RegisterType<EFBlogTagDal>().As<IBlogTagDal>().SingleInstance();

            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<TagService>().As<ITagService>().SingleInstance();
            builder.RegisterType<EFTagDal>().As<ITagDal>().SingleInstance();
        }
    }
}

