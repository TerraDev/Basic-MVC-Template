using Microsoft.AspNetCore.Identity;
using MVCtest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Infrastructure
{
    internal static class SeedData
    {
        public static List<IdentityRole> GetSeedRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole(RolesEnum.NormalUser.ToString())
                {
                    Id = "D0074DD6-E540-45D4-A804-5E1A42C81661"
                },
                new IdentityRole(RolesEnum.Admin.ToString())
                {
                    Id = "29D9873B-8339-4E70-8DE4-544507529A74"
                },
                new IdentityRole(RolesEnum.SuperAdmin.ToString())
                {
                    Id = "15337A34-8592-4417-8C9E-ACF960B00102"
                }
            };
        }

        public static AppUser GetSeedUsers()
        {
            AppUser appUser = new AppUser()
            {
                Email = "Sadmin@g.com",
                NormalizedEmail = "Sadmin@g.com".ToUpper(),
                EmailConfirmed = true,
                Id = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                UserName = "ادمین کل",
                NormalizedUserName = "ادمین کل".ToUpper(),
            };

            var hasher = new PasswordHasher<AppUser>();
            //hasher.HashPassword(appUser, "secret123");
            appUser.PasswordHash = hasher.HashPassword(appUser, "secret123");
            return appUser;
        }

        public static IdentityUserRole<string> GetSeedUserRoles()
        {
            return new IdentityUserRole<string>()
            {
                UserId = "B37C0271-DDD7-4124-AD52-69360F5A219F",
                RoleId = "15337A34-8592-4417-8C9E-ACF960B00102"
            };
        }
    }
}
