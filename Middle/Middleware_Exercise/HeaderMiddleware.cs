namespace Middleware_Exercise;
public class HeaderMiddleware
{
    private readonly RequestDelegate _next;
    
    public HeaderMiddleware(RequestDelegate next){
        _next = next;
    }
}
