using FabuRobotics.Api.Models;
using FabuRobotics.Api.Services;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<RobotService>();


var apiKey = builder.Configuration.GetValue<string>("OPENAI_API_KEY");

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
}

app.UseHttpsRedirection();
app.Use(async (context, next) =>
{
    context.Response.Headers["X-FabuRobotics-Api"] = "1.0";
    await next(context);
});

app.MapGet("/robots", (RobotService robotService) => robotService.GetAll())
    .WithName("GetRobots");

app.MapGet("/robots/{code}", Results<Ok<Robot>, NotFound> (string code, RobotService robotService) =>
    robotService.GetByCode(code) is { } robot
        ? TypedResults.Ok(robot)
        : TypedResults.NotFound())
    .WithName("GetRobotByCode");

app.Run();