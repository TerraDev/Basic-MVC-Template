using Microsoft.Extensions.DependencyInjection;
using MVCtest.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Application
{
    public static class ServiceDependencyInjection
    {
        public static void AddCustomServices(this IServiceCollection service)
        {
            service.AddScoped<UserService>();
            service.AddScoped<ItemService>();

            service.AddSingleton<FileService>();
        }
    }
}
