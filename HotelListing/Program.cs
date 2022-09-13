 
using HotelListing;
using HotelListing.Configurations;
using HotelListing.Data;
using HotelListing.IRepasitary;
using HotelListing.Repository;
using HotelListing.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
  
using System.Text;

var builder = WebApplication.CreateBuilder(args);
 

// Add services to the container.

Log.Logger = new LoggerConfiguration()
    .WriteTo.File(

    path: "C:\\Users\\Hp\\Desktop\\c#\\HotelListing\\HotelListing\\logs\\log-.txt",
     outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz}  {Level:u3}]   {Message:lj}{NewLine}{Exception}",
      rollingInterval: RollingInterval.Day,
      restrictedToMinimumLevel: LogEventLevel.Information
    ).CreateLogger();
try
{
    Log.Information("Application is starting");

}
catch (Exception ex)
{
    Log.Fatal(ex, "Application is FAild To start "); 
}
finally
{
    Log.CloseAndFlush();
}
builder.Services.AddControllers().AddNewtonsoftJson(op => 
op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
         
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.ConfigureIdentity();
//builder.Services.ConfigureJWT();
builder.Services.AddAuthorization();

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());  
});
builder.Services.AddAutoMapper(typeof(MapperInitilizer));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddDbContext<DatabaseConext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection")));

 
var app = builder.Build();

 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
  
//app.UseEndpoints(endpoints =>

//{

//    endpoints.MapControllerRoute(
//      name: "defult",
//      pattern: "{controller=Home}/{action=Index}/{id?}"); 
//    endpoints.MapControllers();
//});
app.MapControllers();
app.UseCors("AllowAll");
app.Run();
