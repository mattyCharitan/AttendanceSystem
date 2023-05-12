using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Modules;
using System;

namespace Repositories
{
    public static class ServiceCollectionExtensions
    {
        private static string ReplaceWithCurrentLocation(string connStr)
        {
            string str = AppDomain.CurrentDomain.BaseDirectory;
            string directryAboveBin = str.Substring(0, str.IndexOf("\\bin"));
            string twoDirectoriesAboveBin = directryAboveBin.Substring(0, directryAboveBin.LastIndexOf("\\"));
            connStr = string.Format(connStr, twoDirectoriesAboveBin);
            return connStr;
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IItemRepository, ItemRepository>();
            // services.AddScoped<IOutfitRepository, OutfitRepository>();
            // services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            
            string connStr = ReplaceWithCurrentLocation("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = {0}\\DB\\AttendanceDatabase.mdf; Integrated Security = True;");
            services.AddDbContext<AttendanceContext>(options => options.UseSqlServer(connStr));
        }
    }
}
