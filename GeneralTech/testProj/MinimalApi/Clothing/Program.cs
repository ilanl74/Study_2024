using Clothing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();// important
var defaultConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(defaultConnectionString);
builder.Services.Configure<CSettings>(builder.Configuration.GetSection("MySettings"));
builder.Services.AddCMiddleware();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CMiddleware>();
app.Use(async (context, next) =>
{
    Console.WriteLine("middleware action before routing");
    await next(context);
    Console.WriteLine("after calling the controller response has started ={0}", context.Response.HasStarted);
});
app.Use(async (content, next) =>
{
    Console.WriteLine("second custom start");
    await next(content);
    Console.WriteLine("second custom end");
});

//app.UseRouting();

app.UseHttpsRedirection();
app.MapControllers();// important
app.Run();
/*
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}*/
