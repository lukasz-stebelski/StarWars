using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using StarWars.WebAPI.Options;
using System;
using System.Threading.Tasks;

namespace StarWars.WebAPI.ApiKey
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class ApiKeyAuthAttribute : Attribute, IAsyncActionFilter
    {
        public const string ApiKeyHeaderName = "Authorization";
        public const string ApiKeyPrefix = "ApiKey";
        private readonly IOptions<ApiOptions> apiOptions;

        public ApiKeyAuthAttribute(IOptions<ApiOptions> apiOptions)
        {
            this.apiOptions = apiOptions;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
 
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

    
            var apiKey = $"{ApiKeyPrefix} {apiOptions.Value.ApiKey}";

            if (!apiKey.Equals(providedApiKey[0], StringComparison.InvariantCultureIgnoreCase))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
