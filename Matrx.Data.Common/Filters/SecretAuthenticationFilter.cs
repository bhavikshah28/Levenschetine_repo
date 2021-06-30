using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Authorization;   
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace Matrix.Data.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public sealed class SecretAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private BaseManager baseManager;
        private readonly IHttpContextAccessor _contextAccessor;
        public SecretAuthenticationFilter(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public SecretAuthenticationFilter()
        {

        }

        /// <summary>
        /// Check authtoken is valid or not
        /// </summary>
        /// <param name="authorizationFilterContext"></param>
        public void OnAuthorization(AuthorizationFilterContext authorizationFilterContext)
        {
            baseManager = new BaseManager(_contextAccessor);
            const string AuthTokenName = "SecretKey";
            bool IsValid = false;

            if(!authorizationFilterContext.Filters.Any(item => item is IAllowAnonymousFilter))
            {
                ServiceResponse serviceResponse = new ServiceResponse();
                var authToken = authorizationFilterContext.HttpContext.Request.Headers[AuthTokenName].FirstOrDefault();
                IsValid = baseManager.ValidateAuthToken(authToken);
                if (!IsValid)
                {
                    serviceResponse.Status = (int)HttpStatusCode.Unauthorized;
                    serviceResponse.Message = "Unauthorized Access.";
                    authorizationFilterContext.Result = new JsonResult(string.Empty)
                    {
                        Value = serviceResponse,
                        StatusCode = (int)HttpStatusCode.OK
                    };
                }
            }
        }
    }
}
