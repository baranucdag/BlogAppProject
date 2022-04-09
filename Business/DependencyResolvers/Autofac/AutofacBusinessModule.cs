using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstact;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers;
using Core.Security.JWT;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

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

            builder.RegisterType<ImageService>().As<IImageService>().SingleInstance();
            builder.RegisterType<EFImageDal>().As<IImageDal>().SingleInstance();

            builder.RegisterType<CommentService>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EFCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

