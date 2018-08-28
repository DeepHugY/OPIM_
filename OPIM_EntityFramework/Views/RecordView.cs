using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
   public class RecordView
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Source { get; set; }
        public decimal Money { get; set; }
        public string Remark { get; set; }
        public string CreateOn { get; set; }
        public Guid CreateBy { get; set; }
        public string TypesName { get; set; }
        public int InOrOut { get; set; }
    }
}
