using Microsoft.EntityFrameworkCore;
using MVCTASK.Data;
using MVCTASK.Services.Interfaces;
using MVCTASK.Services.ServicesClasses;
using MVCTASK.Services.ServicesFile;

namespace MVCTASK
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var con = builder.Configuration.GetConnectionString("DefaultConnection") ??
                 throw new InvalidOperationException("not database found");
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(con));

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();
            builder.Services.AddSingleton<FileService>();
            builder.Services.AddScoped<IInstructorsService, InstructorsService>();
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
            app.UseSession();
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
