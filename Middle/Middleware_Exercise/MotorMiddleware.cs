namespace Middleware_Exercise;
public class MotorMiddleware
{
    private readonly RequestDelegate _next;
    public MotorMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("Motor instalado ao carro\n");
        await _next.Invoke(context);
    }
}
