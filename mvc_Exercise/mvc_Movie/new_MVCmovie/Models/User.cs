namespace new_MVCmovie.Models;
public class User
{
    public int Id { get; set;}
    public required string username { get; set; }
    public required string password { get; set; }
    public required string role { get; set; }
}
