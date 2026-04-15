using System.Security.Claims;

namespace AIMCPHub.Utils.Extensions
{
    public static class UserExtensions
    {
        
            public static string GetUserId(this ClaimsPrincipal user)
                => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            public static string GetUsername(this ClaimsPrincipal user)
                => user.FindFirst(ClaimTypes.Name)?.Value;

            public static string GetRole(this ClaimsPrincipal user)
                => user.FindFirst(ClaimTypes.Role)?.Value;

            public static List<string> GetPermissions(this ClaimsPrincipal user)
                => user.Claims
                    .Where(c => c.Type == "permission")
                    .Select(c => c.Value)
                    .ToList();
        
    }
}
