using System.ComponentModel.DataAnnotations;

namespace new_MVCmovie.Models;
public class Movie
{
    public int MovieId { get; set; }
    public int StudioId { get; set; }
    public string Title { get; set; } = string.Empty;
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; } 
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; } 

    public ICollection<Artist> Artists { get; set; } = new List<Artist>();
}
