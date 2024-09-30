using CommunityToolkit.Maui;
using LW2.Model.Entities;
using LW2.Model.Interfaces;
using LW2.Model.Services;
using LW2.View;
using LW2.Viewmodel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LW2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContextFactory<IndustrialDbContext>(options => options.UseMySQL("server=127.0.0.1;uid=root;pwd=root;database=LW2"));

            //builder.Services.AddTransient<IIndustrialRepository, MockIndustrialRepository>();
            builder.Services.AddTransient<IIndustrialRepository, IndustrialRepository>();

            builder.Services.AddTransient<ProductionAreasTab>();
            builder.Services.AddTransient<ProductionAreasViewmodel>();

            builder.Services.AddTransient<EquipmentTypesTab>();
            builder.Services.AddTransient<EquipmentTypesViewmodel>();

            builder.Services.AddTransient<EmployeesTab>();
            builder.Services.AddTransient<EmployeesViewmodel>();

            builder.Services.AddTransient<EquipmentTab>();
            builder.Services.AddTransient<EquipmentViewmodel>();

            builder.Services.AddTransient<InspectionsTab>();
            builder.Services.AddTransient<InspectionsViewmodel>();

            builder.Services.AddTransient<FailuresTab>();
            builder.Services.AddTransient<FailuresViewmodel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
