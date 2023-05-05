using Dotnet6MVC.Data;
using Dotnet6MVC.IRepository;
using Dotnet6MVC.Middleware;
using Dotnet6MVC.Repository;
using DotNet6MVCWebApp.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseWebRoot("").UseStaticWebAssets();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HoshmandDBContext>(x => x.UseSqlServer(connectionString));

//Authentication
//builder.Services.AddAuthentication(option =>
//{
//    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//}).AddCookie(options =>
//        {
//            options.LoginPath = "/Logins/UserLogin/";
//            options.AccessDeniedPath = "/AccessDenied";
//           options.ExpireTimeSpan = TimeSpan.FromHours(2);
//        });

//builder.Services.AddDistributedMemoryCache();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromHours(2);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;

//});

//builder.Services.ConfigureApplicationCookie(option =>
//{
//    option.ExpireTimeSpan = TimeSpan.FromMinutes(540);
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("HasAccess", policy => policy.AddRequirements(new HasAccessRequirment()));
//});

//builder.Services.AddTransient<IAuthorizationHandler, HasAccessHandler>();
builder.Services.AddTransient<IMvcControllerDiscovery, MvcControllerDiscovery>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

//app.UseMiddleware<MyExceptionHandlerMiddleware>();
//app.UseMiddleware<MyShortCircuitMiddleware>();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapBlazorHub();

//app.UseAuthentication();
//app.UseCookiePolicy();
//app.UseSession();
app.UsePathBase("/BlazorWebAssmApp");


app.UseRouting();

app.UseEndpoints(endpoints => 
{ 
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=UserProfiles}/{action=Index}/{id?}");
    endpoints.MapFallbackToFile("index.html");
    endpoints.MapBlazorHub();

});

app.Run();
