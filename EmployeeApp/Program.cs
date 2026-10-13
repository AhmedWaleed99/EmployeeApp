using EmployeeApp.Models;
using EmployeeApp.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDBContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false; 
                option.Password.RequiredLength = 3; 
                option.Password.RequireLowercase = false; 
                option.Password.RequireUppercase = false; 
                option.Password.RequiredUniqueChars = 0; 
                option.Password.RequireNonAlphanumeric = false; 


            }).AddEntityFrameworkStores<AppDBContext>();

            builder.Services.AddScoped<IDepartmentRepository , DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository , EmployeeRepository>();
            builder.Services.AddScoped<IPenaltyTypeRepository, PenaltyTypeRepository>();
            builder.Services.AddScoped<IEmployeePenalty, EmployeePenaltyRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseRouting();
            app.UseAuthentication();

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
