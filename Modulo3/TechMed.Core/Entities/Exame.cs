namespace TechMed.Core.Entities;
public class Exame : BaseEntity
{
    public int ExameId { get; set; }
    public DateTime dataHora { get; set; } = DateTime.Now;
    public required int AtendimentoId { get; set; }    
}
