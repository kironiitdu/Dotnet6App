using Dotnet6App.Data;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Middleware;
using DotNet6MVCWebApp.Service;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext = DotNet6MVCWebApp.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IService, Service>();
//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
//builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();


//builder.Services.AddAntiforgery(options =>
//{
//    // Set Cookie properties using CookieBuilder properties†.
//    options.FormFieldName = "AntiforgeryFieldname";
//    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
//    options.SuppressXFrameOptionsHeader = false;
//});
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<SampleExceptionFilter>();
});
//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add<SetTempDataModelStateAttribute>();
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
//app.UseMiddleware<SampleExceptionFilter>();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.UseEndpoints(cR =>
//   cR.MapRoute("default", "{controller}/{action}", null, null,
//   new { Namespace = "DotNet6MVCWebApp.Controllers.CategoryController" }));



app.Run();
