using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Common.DataModels
{
    public class ShowBudgetModel
    {
        public Guid Id { get; set; }
        public string TypeName { get; set; }
        public int InOrOut { get; set; }
        public decimal Money { get; set; }
       public decimal Expense { get; set; }
        public bool IsEdit { get; set; }
    }
}
