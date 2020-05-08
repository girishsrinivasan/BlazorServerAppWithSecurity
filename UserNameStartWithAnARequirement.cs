using Microsoft.AspNetCore.Authorization;

namespace BlazorServerAppWithSecurity
{
    public class UserNameStartWithAnARequirement : IAuthorizationRequirement
    {
    }
}