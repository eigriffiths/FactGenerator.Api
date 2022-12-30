using FactGenerator.Core.Services;
using FactGenerator.Core.Services.Interfaces;
using FactGenerator.Repo.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactGenerator.Api.Helpers
{
    public static class StartupHelper
    {
        public static void RegisterTypes(this IServiceCollection services)
        {
            services.AddScoped<IFactService, FactService>();
        }

        public static void MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}
