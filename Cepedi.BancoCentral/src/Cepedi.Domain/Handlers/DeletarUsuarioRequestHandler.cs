using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;

namespace Cepedi.Domain.Handlers;
public class DeletarUsuarioRequestHandler : IRequestHandler<DeletarUsuarioRequest, DeletarUsuarioResponse>
{
    private readonly IUsuarioRepository _usuarioRepository;

    public DeletarUsuarioRequestHandler(IUsuarioRepository usuarioRepository){
        _usuarioRepository = usuarioRepository;
    }

    public async Task<DeletarUsuarioResponse> Handle(DeletarUsuarioRequest request, CancellationToken cancellationToken){
        var usuario = await _usuarioRepository.ObterUsuarioAsync(request.Id);

        if (usuario == null){
            return new DeletarUsuarioResponse(false);
        } else {
            await _usuarioRepository.DeletarUsuarioAsync(usuario);
            return new DeletarUsuarioResponse(true);
        }
    }
}
