using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace idsrv1.idsrv4
{
    public class MyProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}
