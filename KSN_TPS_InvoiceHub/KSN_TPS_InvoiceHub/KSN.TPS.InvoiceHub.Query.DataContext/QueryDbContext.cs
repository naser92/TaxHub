using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using PDN.TPS.Framework.Core.Infrastructure;
using PDN.TPS.Framework.Mq;
using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.Query.DataContext
{
    public class QueryDbContext : QueryFrameworkDbContext
    {
        public QueryDbContext(DbContextOptions options, IPublisher publisher) : base(options, publisher)
        {
        }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //new BaseBankMapping(modelBuilder.Entity<BaseBankModel>());

        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(BaseBuyerTypeMapping).Assembly);
        //    base.OnModelCreating(modelBuilder);
        //}


        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<QueryDbContext>
        {
            private ITypeFinder _typeFinder;

            public DesignTimeDbContextFactory()
            {
            }

            public DesignTimeDbContextFactory(ITypeFinder typeFinder)
            {
                _typeFinder = typeFinder;
            }

            public QueryDbContext CreateDbContext(string[] args)
            {
                //var configuration = new ConfigurationBuilder()
                //    .SetBasePath(Directory.GetCurrentDirectory().Replace("DataContext", "Api"))
                //    .AddJsonFile("appsettings.Development.json")
                //    .Build();


                //var builder = new DbContextOptionsBuilder<QueryDbContext>();

                //var connectionString = configuration.GetConnectionString("ReadConnection");

                //builder.UseSqlServer(connectionString, k => k.UseHierarchyId());


                return null; // new QueryDbContext(builder.Options, null);
            }
        }
    }
}
