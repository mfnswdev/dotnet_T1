using TechMed.Core.Entities;

namespace TechMed.Application.InputModels
{
   public class NewExameInputModel
   {
      public DateTime DataHora { get; set; }
      public required int AtendimentoId { get; set; }
   }
}
