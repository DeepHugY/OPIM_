using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Views
{
    public class BudgetWithTypeView
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public int InOrOut { get; set; }
        public decimal Money { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public Guid CreateBy { get; set; }
    }
}
