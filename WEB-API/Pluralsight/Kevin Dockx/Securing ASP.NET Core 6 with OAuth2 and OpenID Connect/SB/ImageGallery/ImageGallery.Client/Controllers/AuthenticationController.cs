using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Client.Controllers
{
    public class AuthenticationController : Controller
    {
        [Authorize]
        public async Task Logout()
        {
            await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, CookieAuthenticationDefaults.AuthenticationScheme);

            await Microsoft.AspNetCore.Authentication.AuthenticationHttpContextExtensions.SignOutAsync(HttpContext, OpenIdConnectDefaults.AuthenticationScheme);
        }
    }
}
