using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class PacienteRepository : IPacienteRepository
{
    private TechMedContext Context;
    public async Task<Paciente> GetByName(string nome, CancellationToken cancellationToken)
    {

        var entity = await Context.Pacientes.FirstOrDefaultAsync(x => x.Nome == nome, cancellationToken);
        if (entity == null)
        {
            throw new Exception($"Entity {nameof(Paciente)} with name {nome} not found");
        }
        return entity;

    }

}
