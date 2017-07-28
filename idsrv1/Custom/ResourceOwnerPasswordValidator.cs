using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace idsrv1.Custom
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var user = context.UserName;
                var pwd = context.Password;
                if (user != null &&
                        user == "alice" && pwd == "password")
                {
                    context.Result = new GrantValidationResult(
                                        subject: "alice",
                                        authenticationMethod: "custom",
                                        claims: new[] { new Claim("name", "whatever") }
                    );
                }
                else
                {
                    context.Result = new GrantValidationResult(
                                    TokenRequestErrors.InvalidGrant,
                                    "invalid custom credential");
                }
            });           
        }
    }
}
