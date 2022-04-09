using Business.Constans;
using Core.Extensions;
using Core.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Business.CrossCuttingConcerns.SecuredOperation
{
    public class SecuredOperationTool
    {
        private string[] roles;
        private IHttpContextAccessor httpContextAccessor;
        public SecuredOperationTool(string roles)
        {
            this.roles = roles.Split(',');
            this.httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            this.SecuredOperation();
        }
    
        public void SecuredOperation()
        {
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
