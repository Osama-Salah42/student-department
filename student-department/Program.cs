using student_department.BLL;
using student_department.Models;

namespace student_department
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IStudent, StudentBLL>();
            builder.Services.AddSession();

            var app = builder.Build();
            /*app.Use(async (context, next) =>
           {
               await context.Response.WriteAsync("Hello ");
               //await next();
               await next.Invoke();
               await context.Response.WriteAsync(" I said Hello!");
           });
           app.Run(async context =>
           {
               await context.Response.WriteAsync("Welcome");
           });*/

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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Course}/{action=Details}/{id?}");

            app.Run();
        }
    }
}