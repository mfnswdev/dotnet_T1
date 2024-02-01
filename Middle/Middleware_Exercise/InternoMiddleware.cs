namespace Middleware_Exercise;
public class InternoMiddleware
{
    private readonly RequestDelegate _next;
    public InternoMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        await context.Response.WriteAsync("Componentes Internos instalados ao carro\n");
        await _next.Invoke(context);
    }
}
