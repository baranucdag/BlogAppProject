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


            builder.RegisterType<CategoryService>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EFCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<CommentService>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EFCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<FavService>().As<IFavService>().SingleInstance();
            builder.RegisterType<EFFavDal>().As<IFavDal>().SingleInstance();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<EFUserDal>().As<IUserDal>();

            builder.RegisterType<AuthService>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<OperationClaimService>().As<IOperationClaimService>();
            builder.RegisterType<EFOperationClaimDal>().As<IOperationClaimDal>();

            builder.RegisterType<UserOperationClaimService>().As<IUserOperationClaimService>();
            builder.RegisterType<EFUserOperationClaimDal>().As<IUserOperationClaimDal>();


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

