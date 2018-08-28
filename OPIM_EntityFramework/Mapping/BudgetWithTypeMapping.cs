using OPIM_EntityFramework.Views;
using System.Data.Entity.ModelConfiguration;

namespace OPIM_EntityFramework.Mapping
{
    public class BudgetWithTypeMapping : EntityTypeConfiguration<BudgetWithTypeView>
    {
        public BudgetWithTypeMapping()
        {
            this.ToTable(OPIM_Common.ViewName.BudgetWithType);
        }
    }
}
