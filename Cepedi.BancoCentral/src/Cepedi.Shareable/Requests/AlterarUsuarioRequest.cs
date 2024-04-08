using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Shareable.Requests;
public class AlterarUsuarioRequest : IRequest<AlterarUsuarioResponse>
{
    public string Nome { get; set;} = default!;
    public string Email { get; set;} = default!;
    public string Celular { get; set;} = default!;
    public bool CelularValidado { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; } = default!;

    public int Id { get; set; }

}
