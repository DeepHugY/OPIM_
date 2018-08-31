using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OPIM_Common.Extensions
{
    public class Authentication
    {
        public Authentication()
        {

            if (IsLogin)
            {
                var information = ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData;
                string[] arrAtr = information.Split('|');
                memberShipId = Guid.Parse(arrAtr[1]);
                limitLevel = int.Parse(arrAtr[0]);
             }
            else
            {
                HttpContext.Current.Response.Write("<script language='javascript'>window.location='/Others/LockScreen'</script>");
            }
        }
        public bool IsAdmin()
        {
            if (limitLevel < 10)
                return true;
            else
                return false;
        }
        private Guid memberShipId;
        public Guid MemberShipId
        {
            get { return this.memberShipId; }
        }
        private int limitLevel;
        public int LimitLevel
        {
            get { return this.limitLevel; }
        }
        public bool IsLogin
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }
    }
}
