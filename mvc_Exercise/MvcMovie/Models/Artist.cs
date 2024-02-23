namespace MvcMovie.Models;
public class Artist
{
    public int id { get; set; }
    public string? name { get; set; }
    public string? bio { get; set; }
    public string? site { get; set; }

    public ICollection<Movie>? Movies { get; set; }
   
}
