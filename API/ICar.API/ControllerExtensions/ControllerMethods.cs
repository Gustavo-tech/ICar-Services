using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ICar.API.ControllerExtensions
{
    public static class ControllerMethods
    {
        public static string GetUserObjectId(this HttpContext httpContext)
        {
            if (httpContext is null)
                return null;

            Claim claim = httpContext.User.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier");

            return claim?.Value;
        }

        public static string GetUserEmailAddress(this HttpContext httpContext)
        {
            if (httpContext is null)
                return null;

            Claim claim = httpContext.User.FindFirst("emails");

            return claim?.Value;
        }
    }
}
