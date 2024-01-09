using Microsoft.EntityFrameworkCore;

namespace tech_Med.Model;

public class tech_MedContext : DbContext
{
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }

    public tech_MedContext(){
        Database.EnsureCreated();
        Database.EnsureDeleted();
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        base.OnConfiguring(optionsBuilder);
        var stringConnection = "server=localhost;userid=dotnet;password=tic2023;database=tech_med";
        var serverVersion = ServerVersion.AutoDetect(stringConnection);
        optionsBuilder.UseMySql(stringConnection, serverVersion);
    }
}

public abstract class Pessoa {
    public string? nome { get; set; }
    public string? cpf { get; set; }
    public DateTime dataNascimento { get; set; }
}

public class Paciente : Pessoa {
    public string? sexo { get; set; }
    public string? sintomas { get; set; }
}

public class Medico : Pessoa {
    public int crm { get; set; }
}