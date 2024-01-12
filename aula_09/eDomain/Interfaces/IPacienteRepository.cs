
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPacienteRepository : IBaseRepository<Paciente>
{
    Task<Paciente> GetByName(string nome, CancellationToken cancellationToken);
}