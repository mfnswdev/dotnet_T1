using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class MedicoRepository : IMedicoRepository
{
    private TechMedContext Context;
    public async Task<Medico> GetByName(string nome, CancellationToken cancellationToken)
    {

        var entity = await Context.Medicos.FirstOrDefaultAsync(x => x.Nome == nome, cancellationToken);
        if (entity == null)
        {
            throw new Exception($"Entity {nameof(Medico)} with name {nome} not found");
        }
        return entity;

    }

}
