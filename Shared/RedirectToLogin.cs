using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerAppWithSecurity
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            // https://github.com/dotnet/aspnetcore/issues/14464
            // Turn off the debugger breaking from this point in the code
            NavigationManager.NavigateTo("Identity/Account/Login",true);
        }

       
    }
}
