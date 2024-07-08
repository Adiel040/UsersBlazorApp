using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using UserBlazorApp.UI;
using UserBlazorApp.UI.Services;
using UsersBlazorApp.Data.Interfaces;
using UsersBlazorApp.Data.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5265") });
builder.Services.AddScoped<IntServices<AspNetUsers>, UserServices>();
builder.Services.AddScoped<IntServices<AspNetRoles>, RoleServices>();
builder.Services.AddScoped<IntServices<AspNetRoleClaims>, ClaimService>();


await builder.Build().RunAsync();
