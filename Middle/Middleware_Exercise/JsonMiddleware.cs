
namespace Middleware_Exercise;
public class JsonMiddleware
{
    private readonly RequestDelegate _next;

    public JsonMiddleware(RequestDelegate next){
        _next = next;
    }

    public async Task Invoke(HttpContext context){
        try{
            await _next(context);
        }
        catch(Exception e){
            context.Response.StatusCode = 500;
            var strBuilder = new StringBuilder();
            strBuilder.Append("Error");
            strBuilder.Append(");
        }
    }
}


