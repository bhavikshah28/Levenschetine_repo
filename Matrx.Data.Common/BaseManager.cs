using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Matrix.Data.Common
{
    public class BaseManager
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public BaseManager(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        /// <summary>
        /// Check Valid Auth Token 
        /// </summary>
        /// <param name="AuthToken"></param>
        /// <returns></returns>
        public bool ValidateAuthToken(string AuthToken)
        {
            bool IsValid = false;
            IConfigurationBuilder configbuilder = new ConfigurationBuilder();
            configbuilder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = configbuilder.Build();string ConfigAuthToken = root.GetSection("AuthToken") != null ? root.GetSection("AuthToken").Value : string.Empty;
            IsValid = ConfigAuthToken.ToLower().Equals(AuthToken.ToLower());
            return IsValid;
        }

    }
}
