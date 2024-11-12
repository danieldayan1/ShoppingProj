using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class Startup
{
    private static void Main(string[] args)
    {


        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", policy =>
            {
                policy.AllowAnyOrigin()  // Allow requests from any origin
                      .AllowAnyMethod()  // Allow any HTTP method (GET, POST, etc.)
                      .AllowAnyHeader(); // Allow any headers
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseStaticFiles();

        app.UseRouting();

        app.UseCors("AllowAllOrigins");

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllers();

        app.Run();
    }
}