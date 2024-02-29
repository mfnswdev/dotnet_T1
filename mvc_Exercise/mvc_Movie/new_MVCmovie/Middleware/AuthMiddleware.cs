using System.Net;

namespace new_MVCmovie.Middleware;
public class AuthMiddleware
{
    private readonly RequestDelegate _next;
    public AuthMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context){
        
        var token = context.Request.Cookies["token"];

        if (!string.IsNullOrEmpty(token))
        {
            context.Request.Headers.Add("Authorization","Bearer " + token);
        }

        await _next(context);
    }
}
