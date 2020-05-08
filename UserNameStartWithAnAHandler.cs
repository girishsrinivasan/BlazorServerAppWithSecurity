using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerAppWithSecurity
{
    public class UserNameStartWithAnAHandler : AuthorizationHandler<UserNameStartWithAnARequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserNameStartWithAnARequirement requirement)
        {
            String userName = context.User.Identity.Name;
            if(userName != null && userName.StartsWith("A", StringComparison.InvariantCultureIgnoreCase))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
