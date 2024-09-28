using LW2.Model.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace LW2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContextPool<IndustrialDbContext>(
                options => options.UseMySql(
                    GetConnectionString(),
                    AppConfig.ServerVersion,
                    mysqlOptions =>
                    {
                        mysqlOptions.MaxBatchSize(AppConfig.EfBatchSize);
                        
                        if (AppConfig.EfRetryOnFailure > 0)
                        {
                            mysqlOptions.EnableRetryOnFailure(AppConfig.EfRetryOnFailure, TimeSpan.FromSeconds(5), null);
                        }
                    }
            ));
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        private static string GetConnectionString()
        {
            var csb = new MySqlConnectionStringBuilder(AppConfig.ConnectionString);

            if (AppConfig.EfDatabase != null)
            {
                csb.Database = AppConfig.EfDatabase;
            }

            return csb.ConnectionString;
        }
    }
}
