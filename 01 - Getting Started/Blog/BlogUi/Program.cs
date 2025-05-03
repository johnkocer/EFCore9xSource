using BlogUi.Ef;
using Microsoft.EntityFrameworkCore;

namespace BlogUi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      var connection = @"Server=(localdb)\mssqllocaldb;Database=BlogEfDB;Trusted_Connection=True;MultipleActiveResultSets=true";
      builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));
      // Add services to the container.
      builder.Services.AddControllersWithViews();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment())
      {
        app.UseExceptionHandler("/Home/Error");
      }
      app.UseRouting();

      app.UseAuthorization();

      app.MapStaticAssets();
      app.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}")
          .WithStaticAssets();

      app.Run();
    }
  }
}
