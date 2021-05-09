using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlogWebAssembly.Client.Authentication
{
    public class RoleAccountClaimsPrincipalFactory : AccountClaimsPrincipalFactory<RemoteUserAccount>
    {
        public RoleAccountClaimsPrincipalFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
        {
        }

        public async override ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var user=await base.CreateUserAsync(account, options);
            if(user.Identity!=null && user.Identity.IsAuthenticated)
            {
                var identity = (ClaimsIdentity)user.Identity;
                var roleClaims = identity.FindAll(identity.RoleClaimType).ToList();
                if(roleClaims!=null && roleClaims.Any())
                {
                    foreach(var existingClaim in roleClaims)
                    {
                        identity.RemoveClaim(existingClaim);
                    }
                }
                var rolesElem = account.AdditionalProperties[identity.RoleClaimType];
                if(rolesElem is JsonElement roles)
                {
                    if (roles.ValueKind == JsonValueKind.Array)
                    {
                        foreach (var role in roles.EnumerateArray())
                        {
                            var rolestring = role.GetString();
                            if (rolestring != null)
                            {
                                identity.AddClaim(new Claim(options.RoleClaim, rolestring));
                            }
                        }
                    }
                    else
                    {
                        var rolestring = roles.GetString();
                        if (rolestring != null)
                        {
                            identity.AddClaim(new Claim(options.RoleClaim, rolestring));
                        }
                    }
                }
            }
            return user;
        }
    }
}
