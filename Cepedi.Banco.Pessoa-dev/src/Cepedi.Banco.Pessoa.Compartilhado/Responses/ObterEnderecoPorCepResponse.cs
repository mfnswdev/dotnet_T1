namespace Cepedi.Banco.Pessoa.Compartilhado.Responses;


public class ObterEnderecoPorCepResponse
{

    public string cep { get; set; } = default!;
    public string logradouro { get; set; } = default!;
    public string complemento { get; set; } = default!;
    public string bairro { get; set; } = default!;
    public string localidade { get; set; } = default!;
    public string uf { get; set; } = default!;
    public string ibge { get; set; } = default!;
    public string gia { get; set; } = default!;
    public string ddd { get; set; } = default!;
    public string siafi { get; set; } = default!;
}
