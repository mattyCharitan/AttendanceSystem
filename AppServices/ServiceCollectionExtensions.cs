using AppServices.implementations;
using AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserSerivce, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddRepositories();
        }
    }
}
