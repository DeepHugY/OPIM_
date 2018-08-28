using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
   public class MemberShipsView
    {
        public Guid Id { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
        public string Sex { get; set; }
        public DateTime BirthOn { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreateOn { get; set; }
        public int LimitLevel { get; set; }
        public string Icon { get; set; }
    }
}
