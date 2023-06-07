using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using RazorPageDemoApp.Middleware;
using Microsoft.EntityFrameworkCore;
using RazorPageDemoApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

//builder.Services.Configure<RequestLocalizationOptions>(x => {
//    x.DefaultRequestCulture = new RequestCulture("pt");
//    x.SupportedCultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("pt") };
//    x.SupportedUICultures = new List<CultureInfo> { new CultureInfo("en"), new CultureInfo("pt") };
//    x.RequestCultureProviders.Insert(0, new RouteDataRequestCultureProvider
//    {
//        RouteDataStringKey = "culture",
//        UIRouteDataStringKey = "culture",
//        Options = x
//    });

//});

//builder.Services.AddMvc().AddRazorPagesOptions(options =>
//{
//    options.Conventions.AllowAnonymousToPage("/Login");
//});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(30);
                    options.LoginPath = "Login";
                });

//SessionState Config
//builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "_count";
    options.IdleTimeout = TimeSpan.FromMinutes(5);
    options.Cookie.IsEssential = true;
    //options.Cookie.HttpOnly = true;
});

//builder.Services.AddMemoryCache();
//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/Error", "?code={0}");
//app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "Pages")),
    RequestPath = "/Pages"
});
app.UseRouting();
app.UseSession();

//app.UseAuthorization();

app.MapRazorPages();

//app.UseStatusCodePagesWithReExecute("/error/{0}");

//app.UseRequestLocalization();
//app.UseAuthentication();
//app.UseStatusCodePagesWithReExecute("/error", "?code={0}");
//app.Use((context, next) =>
//{
//    var rqf = context.Features.Get<IRequestCultureFeature>();
//    // Culture contains the information of the requested culture
//    var culture = rqf.RequestCulture.Culture;
//    if (culture == null)
//    {
//        context.Response.Redirect("/error/404");
//        context.Response.CompleteAsync();

//    }
//    context.Response.CompleteAsync();
//    return next();
//});


//app.UseMiddleware<RedirectUnsupportedCulturesMiddleware>();
//app.UseEndpoints(endpoints =>endpoints.MapRazorPages());

app.Run();
