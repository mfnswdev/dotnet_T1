using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Middleware_Exercise;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<CronoIpMiddleware>();


app.UseMiddleware<ChassiMiddleware>();
app.UseMiddleware<MotorMiddleware>();
app.UseMiddleware<PortasMiddleware>();
app.UseMiddleware<PinturaMiddleware>();
app.UseMiddleware<InternoMiddleware>();


app.Run();
