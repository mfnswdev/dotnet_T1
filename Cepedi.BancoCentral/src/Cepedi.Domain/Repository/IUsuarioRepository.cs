﻿using Cepedi.BancoCentral.Domain.Entities;

namespace Cepedi.BancoCentral.Domain.Repository;

public interface IUsuarioRepository
{
    Task<UsuarioEntity> CriarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> AlterarUsuarioAsync(UsuarioEntity usuario);
    Task<UsuarioEntity> ObterUsuarioAsync(int id);
    Task<int> DeletarUsuarioAsync(UsuarioEntity usuario);
}
