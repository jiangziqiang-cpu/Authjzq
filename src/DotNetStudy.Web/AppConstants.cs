using System.Security.Claims;

namespace Poseidon.Infrastructure
{
    public  class AppConstants
    {
        public static string UserIdentifier = ClaimTypes.NameIdentifier;
        public static string NameIdentifier = ClaimTypes.Name;
        public static string PermissionClaim = "Poseidon.Roles.Permission";
        public static string OrganizationIdentifier = "Poseidon.Organization.Identifier";
        public static string RoleClaims = "RoleClaims";
    }
}
