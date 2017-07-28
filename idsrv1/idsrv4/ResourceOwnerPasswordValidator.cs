using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace idsrv1.idsrv4
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                var usrname = context.UserName;
                var pwd = context.Password;
                using (var db = new idsrv1.Repository.Oauth1Context())
                {
                    var usr = db.Users.Where(u => u.Username == usrname && u.Password == pwd);
                    if (usr.Count() != 0)
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
                }
               
            });           
        }
    }
}
