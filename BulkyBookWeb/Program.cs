using BulkyBookWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//
        // Resumo:
        //     Initializes a new instance of the Microsoft.AspNetCore.Builder.WebApplicationBuilder
        //     class with preconfigured defaults.
        //
        // Par�metros:
        //   options:
        //     The Microsoft.AspNetCore.Builder.WebApplicationOptions to configure the Microsoft.AspNetCore.Builder.WebApplicationBuilder.
        //
        // Devolu��es:
        //     The Microsoft.AspNetCore.Builder.WebApplicationBuilder.
        
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

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