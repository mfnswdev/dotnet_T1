namespace new_MVCmovie.Models;
public class Artist
{
   public required int ArtistId { get; set; } 
    public string name { get; set; } = null!;
    public string bio { get; set; } = null!;
    public string site { get; set; } = null!;

    public ICollection<Movie>? Movies { get; set; }
}
