using Cepedi.BancoCentral.Domain;
using Cepedi.BancoCentral.Domain.Repository;
using Cepedi.Shareable.Exceptions;
using Cepedi.Shareable.Requests;
using Cepedi.Shareable.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cepedi.BancoCentral.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IMediator _mediator;

    public UserController(
        ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    
    [HttpPost]
    [ProducesResponseType(typeof(CriarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CriarUsuarioResponse>> CriarCursoAsync([FromBody] CriarUsuarioRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(DeletarUsuarioRequest), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeletarUsuarioResponse>> DeletarUsuarioAsync([FromBody] DeletarUsuarioRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPut]
    [ProducesResponseType(typeof(AlterarUsuarioResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErro), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AlterarUsuarioResponse>> AlterarUsuarioAsync([FromBody] AlterarUsuarioRequest request) 
    {
        return await _mediator.Send(request);
    }
    
}
