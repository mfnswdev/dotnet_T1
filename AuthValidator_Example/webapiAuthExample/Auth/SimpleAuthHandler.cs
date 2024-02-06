using System.Text;

namespace webapiAuthExample.Auth;
public class SimpleAuthHandler   
{
    private readonly RequestDelegate _next;

    public SimpleAuthHandler(RequestDelegate next){
            _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        if(!context.Request.Headers.ContainsKey("Authorization"))
        {
            context.Response.Headers.Add("WWW-Authenticate", "Basic");
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Authorization header is missing");
            return;
        } 

        var header = context.Request.Headers["Authorization"].ToString();
        var encodedUsernamePassword = header.Substring(6);
        var decodedUsernamePassword = Encoding.UTF8.GetString(Convert.FromBase64String(encodedUsernamePassword));
        var split = decodedUsernamePassword.Split(':');
        var username = split[0];
        var password = split[1];

        if(username != "admin" || password != "admin")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Invalid username or password");
            return;
        }


        await _next(context);
    }
}
