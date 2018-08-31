using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
   public class AnnouncemrntsView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime CreateOn { get; set; }
    }
}
