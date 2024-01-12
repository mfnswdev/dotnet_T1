using Domain.Entities;

namespace Domain.Interfaces;

public interface IMedicoRepository : IBaseRepository<Medico>
{
    Task<Medico> GetByName(string nome, CancellationToken cancellationToken);
}