using HelloIoC.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelloIoC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = RegisterTypes();

            //var timeService = serviceProvider.GetService<ITimeService>();
            //Console.WriteLine(timeService.GetTime());

            var awesomeService = serviceProvider.GetService<IAwesomeService>();
            awesomeService.DoSomething();

            Console.ReadKey();
        }

        private static ServiceProvider RegisterTypes()
        {
            var container = new ServiceCollection();

            // Wir registrieren die konkrete Implementierung des Service gegen das Interface ITimeService.
            container.AddTransient<ITimeService, CurrentTimeService>();

            // Hier wird die vorherige Registrierung mit einer anderen Implementierung ersetzt.
            container.AddTransient<ITimeService, UniversalTimeService>();

            container.AddTransient<IAwesomeService, AwesomeService>();

            var serviceProvider = container.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
