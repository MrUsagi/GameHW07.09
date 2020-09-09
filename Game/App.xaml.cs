using Game.BuisnessLogic;
using Game.DataLayer.Context;
using Game.DataLayer.Repository;
using Game.ProjectWindows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;

namespace Game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        private void ConfigurationService(IServiceCollection services)
        {

            services.AddSingleton<MainWindowService>();
            services.AddSingleton<AddCharacterService>();
            services.AddSingleton<CharactersSelectionService>();
            services.AddSingleton<HeroesRepository>();
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(CharactersSelectionWindow));
            services.AddTransient(typeof(AddCharacterWindow));
            services.AddTransient(typeof(FightWindow));

            services.AddDbContext<GameContext>(option => option.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            
        }
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json", false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigurationService(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

        }
    }
}
