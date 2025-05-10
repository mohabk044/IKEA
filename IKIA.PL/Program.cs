using IKEA.BLL.Services;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace IKIA.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>((optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            }));
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            //-----------------------------------------------------------------------------------------------------------------------
            //builder.Services.AddScoped<ApplicationDbContext>();
            //builder.Services.AddScoped<DbContextOptions<ApplicationDbContext>>((ServiceProvider)=>
            //{
            //    var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            //    optionsBuilder.UseSqlServer("Server=.;Database=IKEA;Trusted_Connection=True;TrustServerCertificate=True;\"");
            //    var options = optionsBuilder.Options;
            //    return options;
            //});
            //-----------------------------------------------------------------------------------------------------------------------
            #endregion
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
