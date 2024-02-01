namespace Middleware_Exercise;
public class PortasMiddleware
{
    private readonly RequestDelegate _next;
    public PortasMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("Portas instaladas ao carro\n");
        await _next.Invoke(context);
    }
}
