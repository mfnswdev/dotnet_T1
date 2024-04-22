using System.Net;
using System.Text.Json;
using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Entidades;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterEnderecoPorCepRequestHandler : IRequestHandler<ObterEnderecoPorCepRequest, Result<ObterEnderecoPorCepResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<ObterEnderecoPorCepRequestHandler> _logger;
    public ObterEnderecoPorCepRequestHandler(IEnderecoRepository enderecoRepository, ILogger<ObterEnderecoPorCepRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }
    public async Task<Result<ObterEnderecoPorCepResponse>> Handle(ObterEnderecoPorCepRequest request, CancellationToken cancellationToken)
    {
        var endereco = await GetEndereco(request.Cep);
        
        if (endereco == null)
        {
            return Result.Error<ObterEnderecoPorCepResponse>(new Compartilhado.Exceptions.SemResultadosExcecao());
        }

        return Result.Success(endereco);
    }

    public async Task<ObterEnderecoPorCepResponse> GetEndereco(string cep)
    {
        string url = $"https://viacep.com.br/ws/{cep}/json/";

        var client = new HttpClient();
        var response = await client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                var responseContentError = await response.Content.ReadAsStringAsync();
                Console.WriteLine("cai aqui");
                return JsonSerializer.Deserialize<ObterEnderecoPorCepResponse>(responseContentError);
            }
            else
                throw new Exception($"Error: {response.StatusCode} - {response.ReasonPhrase}");
        }
        var responseContent = await response.Content.ReadAsStringAsync();
        var endereco = JsonSerializer.Deserialize<ObterEnderecoPorCepResponse>(responseContent);
        return endereco;
    }
}