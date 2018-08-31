using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
   public class TypesView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int InOrOut { get; set; }
        public DateTime CreateOn { get; set; }
        public Guid CreateBy { get; set; }
        public string Remark { get; set; }
    }
}
