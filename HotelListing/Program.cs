using Serilog;
using Serilog.Events;

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
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());  
}); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowAll");
app.Run();
