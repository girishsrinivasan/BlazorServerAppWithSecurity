using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerAppWithSecurity
{
    public class ApplicationUser : IdentityUser
    {

        public String CustomProperty { get; set; }

        public ApplicationUser()
        {
            CustomProperty = "Default constructor";
        }

        public ApplicationUser(string userName): base(userName)
        {
            CustomProperty = "Constructor with user name parameter";
        }
    }
}
