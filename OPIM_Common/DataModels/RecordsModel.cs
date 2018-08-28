using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common.DataModels
{
    public class RecordsModel
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public string Source { get; set; }
        public decimal Money { get; set; }
        public string Remark { get; set; }
        public string CreateOn { get; set; }
        public Guid CreateBy { get; set; }
    }
}
