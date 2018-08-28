using OPIM_EntityFramework.Views;
using System.Data.Entity.ModelConfiguration;

namespace OPIM_EntityFramework.Mapping
{
    public class MemberShipsMapping : EntityTypeConfiguration<MemberShipsView>
    {
        public MemberShipsMapping()
        {
            this.ToTable(OPIM_Common.TableName.MemberShips);
        }
    }
}
