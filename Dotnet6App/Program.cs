using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Dotnet6App.Data;
using Dotnet6App.Interface;
using Dotnet6App.Repository;
using Microsoft.EntityFrameworkCore;
using Mjml.AspNetCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);





//var endpointDefaultsBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
//                    .AddJsonFile("AnotherJson", true, true)
//                    .AddEnvironmentVariables();
//var productApiSection = endpointDefaultsBuilder.Build();
//var test = productApiSection.GetSection("AnotherConnection");


//var anotherJson = builder.Configuration.GetSection("AnotherConnection");

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:5094",
                                              "https://localhost:7132/api/Values/");
                      });
});



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//add mjml service

builder.Services.AddMjmlServices(o => {
    o.DefaultKeepComments = true;
    o.DefaultBeautify = true;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(config =>
{

}).AddXmlSerializerFormatters();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
