using System.Net;
using System.Text;
using System.Text.Json;

namespace Middleware_Exercise;
public class JsonMiddleware
{
    private readonly RequestDelegate _next;

    public JsonMiddleware(RequestDelegate next){
        _next = next;
    }

    public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _exceptionEndpoint;

    public ExceptionHandlingMiddleware(RequestDelegate next, string exceptionEndpoint)
    {
        _next = next ?? throw new ArgumentNullException(nameof(next));
        _exceptionEndpoint = exceptionEndpoint ?? throw new ArgumentNullException(nameof(exceptionEndpoint));
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            // Captura e formata a exceção
            var exceptionDetails = new
            {
                Message = ex.Message,
                StackTrace = ex.StackTrace
            };

            // Converte os detalhes da exceção para JSON
            var exceptionJson = JsonSerializer.Serialize(exceptionDetails);

            // Envia o JSON para o endpoint especificado
            await SendExceptionToEndpoint(exceptionJson);

            // Define a resposta HTTP para o cliente
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";

            // Retorna o JSON detalhando a exceção ao cliente
            await context.Response.WriteAsync(exceptionJson, Encoding.UTF8);
        }
    }

    private async Task SendExceptionToEndpoint(string exceptionJson)
    {
        // Utiliza HttpClient para enviar o JSON para o endpoint
        using (var httpClient = new HttpClient())
        {
            var content = new StringContent(exceptionJson, Encoding.UTF8, "application/json");
            await httpClient.PostAsync(_exceptionEndpoint, content);
        }
    }
}

}
