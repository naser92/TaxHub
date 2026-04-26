using KSN.TPS.InvoiceHub.Persistence;
using KSN.TPS.InvoiceHub.Query.DataContext;
using Microsoft.EntityFrameworkCore;
using PDN.TPS.Framework.Core.Configuration;
using PDN.TPS.Framework.Core.Infrastructure;
using PDN.TPS.Framework.Core.Persistence;
using PDN.TPS.Framework.Core.Security;
using PDN.TPS.Framework.Extensions;
using PDN.TPS.Framework.Ioc;
using PDN.TPS.Framework.Persistence.EF;

namespace KSN.TPS.InvoiceHub.Api
{
    public class DependencyConfigurator : IDependencyRegistrar
    {
        public int Order => 1;


        public void Register(IServiceCollection services, ITypeFinder typeFinder, AppSettings appSettings)
        {
            services.AddDbContext<WriteDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetRequiredService<SlowQueryInterceptor>());
                options.UseSqlServer(appSettings.GetConnectionStrings("WriteConnection"),
                    b =>
                    {
                        b.MigrationsAssembly("KSN.TPS.InvoiceHub.Persistence");
                        b.CommandTimeout(1800);
                        b.TranslateParameterizedCollectionsToConstants();

                    });
                options.EnableSensitiveDataLogging();
            });
            services.AddDbContext<QueryDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetRequiredService<SlowQueryInterceptor>());
                options.UseSqlServer(appSettings.GetConnectionStrings("ReadConnection"),
                    b =>
                    {
                        b.MigrationsAssembly("KSN.TPS.InvoiceHub.Query.DataContext");
                        b.CommandTimeout(1800);
                        b.TranslateParameterizedCollectionsToConstants();
                    });
            });
            var serviceProvicder = services.BuildServiceProvider();

            services.AddScoped<WriteDbContext>();
            services.AddScoped(typeof(IUnitOfWork), p => p.GetService<WriteDbContext>());

            if (!appSettings.SystemInfo.IsNull())
            {
                SecretKeyAuthFilter.SecretKey = appSettings.SystemInfo.Id.ToString();
            }


        }
    }
}
