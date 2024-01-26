using TechMed.Core.Entities;

namespace TechMed.Application.ViewModels
{
   public class ExameViewModel
   {
      public int ExameId { get; set; }
      public DateTime DataHora { get; set; } = DateTime.Now;
      public required int AtendimentoId { get; set; }

      // public ICollection<AtendimentoViewModel> Atendimentos {get; set;}
     
   }
}
