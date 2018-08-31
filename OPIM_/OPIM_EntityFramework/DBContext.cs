using OPIM_EntityFramework.Mapping;
using System.Data.Entity;

namespace OPIM_EntityFramework
{
    public class DBContext : DbContext
    {
        public DBContext() : base("OPIM")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new RecordMapping())
                                        .Add(new TypesMapping())
                                        .Add(new MemberShipsMapping())
                                        .Add(new AnnouncementMapping())
                                        .Add(new BudgetMapping())
                                        .Add(new BudgetWithTypeMapping());

        }
    }
}