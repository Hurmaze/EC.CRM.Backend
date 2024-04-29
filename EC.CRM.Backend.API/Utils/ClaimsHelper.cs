using System.Security.Claims;
using EC.CRM.Backend.Application.Common;

namespace EC.CRM.Backend.API.Utils
{
    public class ClaimsHelper
    {
        public Guid GetUserUid(HttpContext httpContext)
        {
            var claimIdentity = httpContext.User.Identity as ClaimsIdentity;

            if (claimIdentity is not null)
            {
                var uid = claimIdentity.FindFirst(CustomClaimTypes.Uid)?.Value!;

                if (Guid.TryParse(uid, out Guid result))
                {
                    return result;
                }

                throw new Exception("Uid is not a valid Guid.");
            }

            throw new Exception("Claims were not found.");
        }

        public string GetUserRole(HttpContext httpContext)
        {
            var claimIdentity = httpContext.User.Identity as ClaimsIdentity;

            if (claimIdentity is not null)
            {
                var role = claimIdentity.FindFirst(ClaimTypes.Role)?.Value!;

                return role;
            }

            throw new Exception("Claims were not found.");
        }
    }
}
