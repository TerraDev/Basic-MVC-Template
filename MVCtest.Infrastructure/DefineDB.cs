using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCtest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Infrastructure
{
    public static class DefineDB
    {
        public static void AddCustomDbContext(this IServiceCollection service, string connectionString)
        {
            service.AddDbContext<AppDbContext>(options =>
            {
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            options.UseSqlServer(
            connectionString
            , b => b.MigrationsAssembly("MVCtest.Infrastructure"));
            });

            //I searched for difference between AddIdentityCore, AddIdentity & AddDefaultIdentity
            //AddIdentity & AddDefaultIdentity provide SignInManager
            service.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                //options.Tokens.
            });

            // services.AddDefaultIdentity<ApplicationUser>(options=> //or <IdentityUser>
            //options.SignIn.RequireConfirmedAccount = true)
            //  .AddEntityFrameworkStores<AppDbContext>();
            // --> add package Microsoft.AspNetCore.Identity.UI
        }
    }
}
