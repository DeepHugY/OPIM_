using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common.DataModels
{
   public class ShareModel
    {
        public string Icon { get; set; }
        public string NickName { get; set; }
        public int OPIMAge { get; set; }
        public decimal CurrMonthIn { get; set; }
        public decimal CurrMonthOut { get; set; }
        public List<AnnouncementsView> AnnouncementList { get; set; }
        public string Title { get; set; }
    }
}
