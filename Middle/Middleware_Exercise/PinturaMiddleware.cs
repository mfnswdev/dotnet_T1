namespace Middleware_Exercise;
public class PinturaMiddleware
{
    private readonly RequestDelegate _next;
    public PinturaMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("Pintura aplicada ao carro\n");
        await _next.Invoke(context);
    }
}
