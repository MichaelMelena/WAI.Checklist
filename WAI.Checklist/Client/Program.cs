using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WAI.Checklist.Services;

namespace WAI.Checklist
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            AddServices(builder.Services);

            await builder.Build().RunAsync();
        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddBlazoredLocalStorage();

            services.AddSingleton<IGuidelineParser, GuidelineParser>();
            services.AddSingleton<IGuidlineProvider, GuidlineProvider>();

            services.AddScoped<IProjecLocalStorage, ProjecLocalStorage>();
            
        }
    }
}