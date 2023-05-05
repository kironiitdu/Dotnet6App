
using AutoMapper;
using DotNet6MVCWebApp.Data;
using DotNet6MVCWebApp.Implements;
using DotNet6MVCWebApp.Interface;
using DotNet6MVCWebApp.Middleware;
using DotNet6MVCWebApp.Service;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using System.Text.Json;
using ApplicationDbContext = DotNet6MVCWebApp.Data.ApplicationDbContext;
using DotNet6MVCWebApp.Controllers.APIController;
using DotNet6MVCWebApp.Controllers;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


//builder.Logging.ClearProviders();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));


//builder.Services.AddSingleton<SearchValueTransformer>();
//builder.Services.AddSingleton<IProductLocator, ProductLocator>();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IFileUpload, FileUpload>();
builder.Services.AddScoped<IBookstorerRepository, BookstorerRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
builder.Services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();


//builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
builder.Services.AddSession(option =>
{
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




//builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddControllersWithViews().AddApplicationPart(typeof(UserProfilesController).Assembly);
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    //options.JsonSerializerOptions.Converters.Add(new DateTimeConverterFactory());
    // options.JsonSerializerOptions.Converters.Add(new DecimalConverterFactory());
    // options.JsonSerializerOptions.Converters.Add(new IntConverterFactory());
    //options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    // options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    //options.JsonSerializerOptions.WriteIndented = true;
   // options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

});

//builder.Services.Configure<Microsoft.AspNetCore.Mvc.Razor.RazorViewEngineOptions>(o => {
//    o.ViewLocationFormats.Add("/Views/{0}" + Microsoft.AspNetCore.Mvc.Razor.RazorViewEngine.ViewExtension);
//    o.FileProviders.Add(new Microsoft.Extensions.FileProviders.PhysicalFileProvider(AppContext.BaseDirectory));
//});
builder.Services.AddHttpContextAccessor();
//builder.Services.AddControllersWithViews(options =>
//{

//   options.Filters.Add<SkipTrailingSlashForAdminFilter>();
//    // options.Filters.Add<ActionFilterCheckAuthentication>();
//    // options.Filters.Add<AuthorizeActionFilter>();
//    // options.Filters.Add(new ControllerAndActionDescriptorMiddleware());
//});


builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<ValidateModelStateAttribute>();
});

var MyAllowSpecificOrigins = "_MyAllowSubdomainPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins(
                       "http://localhost:5094",
                       "http://localhost:5094/application/Create",
                       "http://localhost:5094/api/ESmsDialoglk/Login")
                   .WithExposedHeaders("CORS-Response-Header:MY-Exposed-Response-Header");

            //.WithMethods("PUT", "DELETE", "GET");

        });
});
//builder.WebHost.UseUrls("http://localhost:5050/");


var myCorsPolicy = "MyCorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5094", "http://localhost:5094/application/Create", "http://localhost:5094/api/ESmsDialoglk/Login")
            .WithExposedHeaders("authorization")
            .WithMethods("PUT", "DELETE", "GET", "POST");
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
//app.UseMiddleware<RedirectionMiddleware>();
app.UseStaticFiles();
//app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(MyAllowSpecificOrigins);

//app.Use(async (context, next) =>
//{
//    // Parse the URL path and extract the relevant information
//    var path = context.Request.Path.ToString();
//    if (path.StartsWith("/api/img/get"))
//    {
//        //var segments = path.Split('/').Skip(3).ToArray();
//        //var controller = new ImgController();
//        ////await controller.Get(context, segments);
//        //var getNameFromRouteValue = context.Request.RouteValues.Values;

//        var querystring = "TEST/12/HELLO";//getNameFromRouteValue.ToList()[2].ToString();
//        context.Request.RouteValues.Clear();
//        //context.Request.Path = "/api/img/get";
//        //context.Request.QueryString = QueryString.Create("parameters", querystring); //new QueryString($"?parameters={querystring}");
//        context.Response.Redirect($"/api/img/get?parameters={querystring}");
//        var TEST = "";
//        //foreach (var item in getNameFromRouteValue)
//        //{

//        //}

//        //return;
//    }

//    await next();
//});

app.UseAuthorization();
app.UseCors(myCorsPolicy);
app.UseSession();
//app.Use((context, next) =>
//{
//    var host = context.Request.Host.Host;
//    Console.WriteLine(host);
//    return next.Invoke();
//});



var defaultCulture = "en-US";
var ci = new CultureInfo(defaultCulture);

//ci.NumberFormat.CurrencyGroupSeparator = ","; // Defining my preferrence
//ci.NumberFormat.NumberGroupSeparator = ",";



Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

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

//app.MapGet("/", async context =>
//{
//    var originalUrl = context.Request.GetDisplayUrl();

//    var routeToCallFirst = "api/ShibAuth";

//    var updateUrl = (new UriBuilder(originalUrl) { Host = context.Request.Host.Host, Path = routeToCallFirst }).Uri;

//    context.Response.Redirect(updateUrl.AbsoluteUri);

//});


//app.Use((ctx, next) =>
//{
//    var headers = ctx.Response.Headers;

//    headers.Add("Kiron-custom-response-header", "test");
//    return next();
//});

//app.UseMiddleware<IFromToJsonMiddleware>();
//app.UseMiddleware<RemoveEncodingFromURLMiddleware>();
//app.UseMiddleware<SetRequestPathMiddleware>();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllers();
//app.UseEndpoints(cR =>
//   cR.MapRoute("default", "{controller}/{action}", null, null,
//   new { Namespace = "DotNet6MVCWebApp.Controllers.CategoryController" }));

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapDynamicControllerRoute<SearchValueTransformer>("search/{**product}");
//});


app.UseDeveloperExceptionPage();

app.Run();
public class MyCustomCertificateValidationService
{
    public bool ValidateCertificate(X509Certificate2 clientCertificate)
    {
        // todo: check certificate thumbnail
        return false;
    }
}
public class IntConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(int) ||
            typeToConvert == typeof(int?);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        //You may be tempted to cache these converter objects. 
        //Don't. JsonSerializer caches them already.
        if (typeToConvert == typeof(int))
        {
            return new IntConverter();
        }
        else if (typeToConvert == typeof(int?))
        {
            return new NullableIntConverter();
        }

        throw new NotSupportedException("CreateConverter got called on a type that this converter factory doesn't support");
    }
}

public class IntConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            var stringValue = reader.GetString();
            var tokenSquence = reader.ValueSequence;
        }
        catch (Exception ex)
        {

            throw;
        }

        //return IntExtensions.GetFormattedInt(stringValue);
        return 0;
    }

    public override void Write(
        Utf8JsonWriter writer,
        int objectToWrite,
        JsonSerializerOptions options)
    {
        writer.WriteNumberValue(objectToWrite);
    }
}

public class NullableIntConverter : JsonConverter<int?>
{
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.GetString() is { } value)
        {
            //return IntExtensions.GetFormattedInt(value);
        }

        return null;
    }

    public override void Write(
        Utf8JsonWriter writer,
        int? objectToWrite,
        JsonSerializerOptions options)
    {
        if (objectToWrite is { })
            writer.WriteNumberValue((int)objectToWrite);
        else writer.WriteNullValue();
    }
}