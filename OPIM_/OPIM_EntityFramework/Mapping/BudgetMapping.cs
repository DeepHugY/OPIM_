using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_EntityFramework.Mapping
{
    public class BudgetMapping : EntityTypeConfiguration<BudgetView>
    {
        public BudgetMapping()
        {
            this.ToTable(OPIM_Common.TableName.Budget);
        }
    }
}
