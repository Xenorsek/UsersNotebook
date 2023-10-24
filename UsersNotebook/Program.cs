using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersNotebook.Data.Context;
using UsersNotebook.Helpers;
using UsersNotebook.Middlewares;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//services
builder.Services.AddDependencyInjection(configuration);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
        settings =>
        {
            settings.CommandTimeout(10);
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
