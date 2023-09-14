using Advanced_Csharp_Lab2_Blazor.Data;
using Advanced_Csharp_Lab2_Blazor.Models;
using Advanced_Csharp_Lab2_Blazor.Models.sqlite;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace Advanced_Csharp_Lab2_Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddScoped<MenuService>();
            builder.Services.AddScoped<SQLiteService>();
            // using options from appsettings.json
            builder.Services.Configure<WordpressApiOptions>(builder.Configuration.GetSection("WordpressApiOptions"));          
            builder.Services.AddSingleton<WordpressApiService>();
            //using appsettings to build db service, also using frameworkcore proxies to lazy load
            builder.Services.AddDbContext<SchoolContext>(options =>
            options.UseLazyLoadingProxies().UseSqlite(builder.Configuration.GetConnectionString("SQLite")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}