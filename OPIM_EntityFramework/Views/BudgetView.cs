using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
   public class BudgetView
    {
        public Guid Id { get; set; }
        public Guid TypeId { get; set; }
        public decimal Money { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid CreateBy { get; set; }
    }
}
