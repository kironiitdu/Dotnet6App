//using Dotnet6App.Repository;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SwaggerWebAPIApp.Controllers;
using SwaggerWebAPIApp.Data;
using SwaggerWebAPIApp.Interface;
using SwaggerWebAPIApp.Middleware;
using SwaggerWebAPIApp.Repository;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEfFeatureDal, EfFeatureDal>();




//builder.Services.Add(new ControllerAndActionDescriptorMiddleware());

//builder.Services.AddScoped<IProductReposiotry, ProductRepository>();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    

   // options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

});

// Add services to the container.
//builder.Services.AddControllers(options => { options.ModelBinderProviders.Insert(0, new ProductEntityBinderProvider()); });
//builder.Services.AddControllers()
//    .ConfigureApiBehaviorOptions(options =>
//    {
//        options.SuppressModelStateInvalidFilter = true; 
//    });
//builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSwaggerGen(x => x.DocumentFilter<SwaggerAPIDocsShorting>());
//builder.Services.AddSwaggerGen(c =>
//{
//    // c.TagActionsBy()
//   // string[] methodsOrder = new string[4] { "get", "post", "put", "delete" };
//    // c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
//   // c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{Array.IndexOf(methodsOrder, apiDesc.HttpMethod.ToLower())}");

//});



builder.Services.AddSwaggerGen(modifyEnumDefultValue =>
{

    modifyEnumDefultValue.UseInlineDefinitionsForEnums(); 
    
});



//builder.Services.AddCors();
//builder.Services.AddControllersWithViews(options =>
//{
//    options.Filters.Add<RestrictSwaggerAccess>();
//});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMiddleware<SwaggerDocumentAuthenticatorMiddleware>();
    app.UseSwagger();
    app.UseSwaggerUI();
  //  app.UseAuthentication();

}
app.UseCors(builder => builder.AllowAnyOrigin());
//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
//app.UseRouting();


//app.UseMiddleware<SwaggerDocumentAuthenticatorMiddleware>();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=UserProfiles}/{action=Index}/{id?}");


//app.Use(async (context, next) =>
//{
//    var yourMessage = "<!DOCTYPE html><html lang=\"en\"><head><title>Base   API is Running</title></head><body><h3>Base API is Running</h3>";
//    await context.Response.WriteAsync(yourMessage);
//    await next(context);
//});


app.Run();



static string page(string message)
{
    return
        @"<html xmlns=""http://www.w3.org/1999/xhtml"">
            <meta httm-equiv='Content-Type' content='text/html; charset=iso-8859-1' />
            <meta http-equiv=""expires"" content=""0"" />
            <title>
            </title >
            <body>
            <h3> " + message + @"
            </h3>
            </body>
            </html>";
}


