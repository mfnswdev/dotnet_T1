using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.BancoCentral.Domain.Entities;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class AlterarUsuarioRequestHandler : IRequestHandler<AlterarUsuarioRequest, AlterarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;


    public AlterarUsuarioRequestHandler(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<AlterarUsuarioResponse> Handle(AlterarUsuarioRequest request, CancellationToken cancellationToken)
    {
        UsuarioEntity usuario = await _usuarioRepository.ObterUsuarioAsync(request.Id);
        if(usuario == null){
            throw new ArgumentException("Usuário não encontrado");
        } else {
            usuario.Nome = request.Nome;
            usuario.Email = request.Email;
            usuario.Celular = request.Celular;
            usuario.Cpf = request.Cpf;
            usuario.DataNascimento = request.DataNascimento;

            await _usuarioRepository.AlterarUsuarioAsync(usuario);

            return new AlterarUsuarioResponse(usuario.Id, usuario.Nome);
        }
    }
}
