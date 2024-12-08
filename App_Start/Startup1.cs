using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(GlobalShop.App_Start.Startup1))]

namespace GlobalShop.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie", // Buradaki boşluğu kaldırdık
                LoginPath = new PathString("/Account/Login") // Ayrıca LoginPath'ı da tam bir yol ile belirtmelisiniz.
            });


        }
    }
}
