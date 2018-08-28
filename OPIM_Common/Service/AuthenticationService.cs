using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace OPIM_Common.Service
{
   public class AuthenticationService
    {
        public void SignIn(Guid Id, string account, int limit, bool createPersistentCookie)
        {
            //SignOut();
            var now = DateTime.Now;
            string information = limit.ToString() + "|" + Id.ToString();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                account,
                now,
                now.AddMinutes(60),
                createPersistentCookie,
                information,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
            {
                HttpOnly = false,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath
            };

            if (FormsAuthentication.CookieDomain != null)
                cookie.Domain = FormsAuthentication.CookieDomain;

            if (createPersistentCookie)
                cookie.Expires = ticket.Expiration;

            //_userInformations = new UserInformations(Id);
            //_userInformations.LoadInformation();

            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        public void SignOut()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();

                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "")
                {
                    Expires = DateTime.Now.AddMinutes(-1),
                };

                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
