using BulkyBook.DataAccess;
using BulkyBook.DataAccess.Repository;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//
        // Resumo:
        //     Initializes a new instance of the Microsoft.AspNetCore.Builder.WebApplicationBuilder
        //     class with preconfigured defaults.
        //
        // Parâmetros:
        //   options:
        //     The Microsoft.AspNetCore.Builder.WebApplicationOptions to configure the Microsoft.AspNetCore.Builder.WebApplicationBuilder.
        //
        // Devoluções:
        //     The Microsoft.AspNetCore.Builder.WebApplicationBuilder.
        
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
