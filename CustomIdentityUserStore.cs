using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServerAppWithSecurity
{
    public class CustomIdentityUserStore : CustomUserStore<ApplicationUser>
    {
        private readonly PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

        public CustomIdentityUserStore()
        {
        }
        public override Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            ApplicationUser identity = new ApplicationUser(normalizedUserName.ToLower());
            return Task.FromResult(identity);
        }
        public override Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            return FindByNameAsync(userId, cancellationToken);
        }

        public override Task<string> GetPhoneNumberAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult("555-555-5555");
        }

        public override Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
        public override Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(hasher.HashPassword(user, user.UserName) );
        }

        public override Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public override Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.UserName);
        }

        public override Task<string> GetSecurityStampAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return Task.FromResult("This never changes");
        }

        public override Task<IList<Claim>> GetClaimsAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            IList<Claim> list = new List<Claim>();
            if (user.UserName.ToLower().StartsWith("admin"))
            {
                list.Add(new Claim(ClaimTypes.Role, "admin"));
            }
            return Task.FromResult(list);
        }

    }
}