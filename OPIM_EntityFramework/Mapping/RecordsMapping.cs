using OPIM_EntityFramework.Views;
using System.Data.Entity.ModelConfiguration;

namespace OPIM_EntityFramework.Mapping
{
    public class RecordMapping : EntityTypeConfiguration<RecordView>
    {
        public RecordMapping()
        {
            this.ToTable(OPIM_Common.ViewName.RecordsWithTypes);
        }
    }
}
