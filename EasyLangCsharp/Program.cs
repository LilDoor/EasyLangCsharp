using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EasyLangCsharp.Data;
using EasyLangCsharp.Models;
using Npgsql;
namespace EasyLangCsharp
{
    public class Program
    {
        public static async void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddDbContext<EasyLangCsharpContext>(options =>
            //    options.UseNpgsql(builder.Configuration.GetConnectionString("EasyLangCsharpContext") ?? throw new InvalidOperationException("Connection string 'EasyLangCsharpContext' not found.")));

            await using var dataSource = NpgsqlDataSource.Create(builder.Configuration.GetConnectionString("EasyLangCsharpContext"));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using(var scope = app.Services.CreateScope())
            {
                var servcies = scope.ServiceProvider;
                SeedUser.Initialize(servcies);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
