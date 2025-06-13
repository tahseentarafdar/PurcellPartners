using Microsoft.Extensions.DependencyInjection;
using PurcellPartners.Interfaces;

namespace PurcellPartners
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            
            services.AddSingleton<IFindGaps, GapFinder>();
            services.AddSingleton<IUI, UI>();

            var serviceProvider = services.BuildServiceProvider();

            var ui = serviceProvider.GetRequiredService<IUI>();
            ui.Run();
        }
    }
}
