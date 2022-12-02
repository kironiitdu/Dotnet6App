
using AutoMapper;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Implements;
using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Middleware;
using DotNet6MVCWebApp.Service;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using ApplicationDbContext = DotNet6MVCWebApp.Data.ApplicationDbContext;

var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<IBookstorerRepository, BookstorerRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();


//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
//builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddSession(option => { 
    option.IdleTimeout = TimeSpan.FromSeconds(5);
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services
    .AddAuthentication(CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate(options =>
    {
        options.AllowedCertificateTypes = CertificateTypes.SelfSigned;
        options.Events = new CertificateAuthenticationEvents
        {
            OnCertificateValidated = context =>
            {
                var validationService = context.HttpContext.RequestServices
                    .GetService<MyCustomCertificateValidationService>();

                if (validationService.ValidateCertificate(context.ClientCertificate))
                {
                    context.Success();
                }
                else
                {
                    context.Fail("invalid cert");
                }

                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                context.Fail("invalid cert");
                return Task.CompletedTask;
            }
        };

    });
//builder.Services.AddAntiforgery(options =>
//{
//    // Set Cookie properties using CookieBuilder properties†.
//    options.FormFieldName = "AntiforgeryFieldname";
//    options.HeaderName = "X-CSRF-TOKEN-HEADERNAME";
//    options.SuppressXFrameOptionsHeader = false;
//});
// Add services to the container.




builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews(options =>
{
   
   options.Filters.Add<SkipTrailingSlashForAdminFilter>();
    // options.Filters.Add<ActionFilterCheckAuthentication>();
    // options.Filters.Add<AuthorizeActionFilter>();
    // options.Filters.Add(new ControllerAndActionDescriptorMiddleware());
});


//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add<SetTempDataModelStateAttribute>();
//});

//var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//        policy =>
//        {
//            policy.WithOrigins(
//                       "http://localhost:5094",
//                       "http://localhost:5094/application/Create")
//                  .WithExposedHeaders("kiron-custom-header:test");

//                 // .WithMethods("PUT", "DELETE", "GET");

//        });
//});
//builder.WebHost.UseUrls("http://localhost:5050/");


var myCorsPolicy = "MyCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5094", "http://localhost:5094/application/Create")
            .WithExposedHeaders("kiron-test-custom-header")
            .WithMethods("PUT", "DELETE", "GET","POST");
        });
});
// ... other configuration




var app = builder.Build();


//if (System.Diagnostics.Debugger.IsAttached)
//{
//    builder.WebHost.UseUrls("http://localhost:5050/");
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseMiddleware<RestrictMainDomainLoginMiddleware>();
app.UseStaticFiles();
//app.UseHttpsRedirection();
app.UseRouting();
//app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseCors(myCorsPolicy);
app.UseSession();


var defaultCulture = "en-US";
var ci = new CultureInfo(defaultCulture);
ci.NumberFormat.NumberDecimalSeparator = "."; // Defining my preferrence
ci.NumberFormat.CurrencyDecimalSeparator = ".";

// Configuring Number Seperator Using Localization middleware
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(ci),
    SupportedCultures = new List<CultureInfo>
    {
        ci,
    },
    SupportedUICultures = new List<CultureInfo>
    {
        ci,
    }
});


//app.Use((ctx, next) =>
//{
//    var headers = ctx.Response.Headers;

//    headers.Add("Kiron-custom-response-header", "test");
//    return next();
//});

//app.UseMiddleware<AuthorizationFilterContext>();

app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
//app.UseEndpoints(cR =>
//   cR.MapRoute("default", "{controller}/{action}", null, null,
//   new { Namespace = "DotNet6MVCWebApp.Controllers.CategoryController" }));



app.Run();
public class MyCustomCertificateValidationService
{
    public bool ValidateCertificate(X509Certificate2 clientCertificate)
    {
        // todo: check certificate thumbnail
        return false;
    }
}
