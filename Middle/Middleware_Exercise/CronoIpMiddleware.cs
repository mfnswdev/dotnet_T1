using System.Diagnostics;

namespace Middleware_Exercise;
public class CronoIpMiddleware
{
    private readonly RequestDelegate _next;

    public CronoIpMiddleware(RequestDelegate next){
        _next = next;
    }
    
  
    public async Task Invoke(HttpContext context){
        DateTime horaStart = DateTime.Now; 
        Stopwatch requestTime = new Stopwatch();
        
        requestTime.Start();
        var ipAddress = context.Connection.RemoteIpAddress;

        context.Response.Headers.Add("X-IP-Address", ipAddress.ToString());
        context.Response.Headers.Add("X-Request-Time-Microseconds", horaStart.ToString());

        await context.Response.WriteAsync("Hora do request: " + horaStart.ToString() + "\n");
        await context.Response.WriteAsync("ipAdress " + ipAddress + "\n");       
        await _next.Invoke(context);
        requestTime.Stop();

        await context.Response.WriteAsync("Tempo de resposta: " + requestTime.ElapsedMilliseconds + " milliseconds\n");
        await context.Response.WriteAsync("Tempo de resposta: " + requestTime.ElapsedTicks + " microseconds\n");
          
    }

}
