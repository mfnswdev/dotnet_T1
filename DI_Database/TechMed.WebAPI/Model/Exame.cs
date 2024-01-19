namespace TechMed.WebAPI.Model;

public class Exame
{
    public int ExameId {get; set;}
    public string? Nome {get; set;}
    public ICollection<Exame>? Exames {get;}
}
