using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common.DataModels
{
   public class BudgetModel
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public decimal Money { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid CreateBy{ get; set; }
    }
}
