namespace Middleware_Exercise;
public class ChassiMiddleware
{
    private readonly RequestDelegate _next;
    public ChassiMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("Chassi instalado ao carro\n");
        await _next.Invoke(context);
    }
}
