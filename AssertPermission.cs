using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorServerAppWithSecurity
{
    public class AssertPermission
    {
        AuthenticationStateProvider _provider;
        UserManager<ApplicationUser> _userManager;
        public AssertPermission(AuthenticationStateProvider provider, UserManager<ApplicationUser> mgr)
        {
            _provider = provider;
            _userManager = mgr;
        }
        public String GetCustomProperty()
        {
            var authState = _provider.GetAuthenticationStateAsync().Result;
            var user = authState.User;
            var myApplicationUser =  _userManager.FindByNameAsync(user.Identity.Name).Result;
            return  myApplicationUser?.CustomProperty ?? "Application user is null";
        }


    }
}
