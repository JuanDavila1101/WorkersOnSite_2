using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using WorkersOnSite_2.Model;
using System.Net.Http;
using System;
//using Microsoft.Extensions.Configuration;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.Extensions.Logging;
//using System.Collections.Generic;
//using System.Text;

namespace WorkersOnSite_2 
{
  public class Program
  {
    public static async Task Main(string[] args)
    {
      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("#app");

      builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

      // These are Http Client Factories
      builder.Services.AddHttpClient<IPersonService, PersonService>(client => client.BaseAddress=new Uri("https://localhost:44354"));
      builder.Services.AddHttpClient<ISiteService, SiteService>(client => client.BaseAddress = new Uri("https://localhost:44354"));
      builder.Services.AddHttpClient<ITeamService, TeamService>(client => client.BaseAddress = new Uri("https://localhost:44354"));
      
      await builder.Build().RunAsync();
    }
  }


  //public void Configure(IApplication)







}
