using TechMed.Application.Services.Interfaces;
using TechMed.Application.InputModels;
using TechMed.Application.ViewModels;
using TechMed.Infrastructure.Persistence.Interfaces;
using TechMed.Core.Entities;
using TechMed.Core.Exceptions;

namespace TechMed.Application.Services;
public class ExameService : BaseService, IExameService
{
  private readonly IAtendimentoService _atendimentoService;
  public ExameService(ITechMedContext context, IAtendimentoService atendimento) : base(context)
  {
    _atendimentoService = atendimento;
  }

  public int Create(NewExameInputModel exame)
  {
    return _atendimentoService.CreatExame(exame.AtendimentoId, exame);

  }

  
  public void Delete(int id)
  {
    _context.ExamesCollection.Delete(id);
  }

  public List<ExameViewModel> GetAll()
  {
    var exames = _context.ExamesCollection.GetAll().Select(e => new ExameViewModel
    {
      AtendimentoId = e.AtendimentoId, 
      ExameId = e.ExameId,
      // Atendimentos = _atendimentoService.GetAll(),

      // _atendimentoService.GetAll(),
    }).ToList();
    return exames;

  }

  
  public ExameViewModel? GetById(int id)
  {
    throw new NotImplementedException();
  }

  public void Update(int id, NewExameInputModel exame)
  {
    _context.ExamesCollection.Update(id, new Exame
    {
      AtendimentoId = exame.AtendimentoId
    });
  }
}
