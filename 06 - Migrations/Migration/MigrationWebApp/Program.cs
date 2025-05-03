using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MigrationWebApp.Models;
using System;
using System.Linq;

namespace MigrationWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container (from Startup.ConfigureServices)
            string connection = @"Server=(localdb)\mssqllocaldb;Database=MigrationDB;Trusted_Connection=True;";
            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Seed the database (from original Program.cs)
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DataContext>();
                    if (!context.Employee.Any()) // Check for Employee data
                    {
                        // Seed the database with employees
                        context.Employee.Add(new Employee() { FirstName = "John", LastName = "Kocer" });
                        context.Employee.Add(new Employee() { FirstName = "Adam", LastName = "Lee" });
                        context.Employee.Add(new Employee() { FirstName = "Jon", LastName = "Walker" });
                        context.Employee.Add(new Employee() { FirstName = "Jen", LastName = "Walker" });
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            // Configure the HTTP request pipeline (from Startup.Configure)
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
