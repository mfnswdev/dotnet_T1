using System;
using System.Collections.Generic;
using System.Linq;


/*
#region Classes
public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }

    public int Idade
    {
        get
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }
    }
}

public class Medico : Pessoa
{
    public int Crm { get; set; }
}

public class Paciente : Pessoa
{
    public string Sexo { get; set; }
    public string Sintomas { get; set; }
}


#endregion

#region Requisitos

public class Program
{
    public static void Main()
    {
        List<Paciente> pacientes = new List<Paciente>();

        Paciente paciente1 = new Paciente()
        {
            Nome = "John Doe",
            DataNascimento = "01/01/1980",
            Cpf = 12345678901,
        };

        // Check if the new paciente's CPF 
        if (pacientes.Exists(m => m.Cpf == paciente1.Cpf))
        {
            Console.WriteLine("CPF number already exists in the collection.");
            // Handle the case when a duplicate CPF is found
        }
        else
        {
            pacientes.Add(paciente1);
            // Continue adding the medico to the collection
        }
        List<Medico> medicos = new List<Medico>();

        Medico medico1 = new Medico()
        {
            Nome = "John Doe",
            DataNascimento = "01/01/1980",
            Cpf = 12345678901,
            Crm = 12345
        };

        if (medicos.Exists(m => m.Cpf == medico1.Cpf || m.Crm == medico1.Crm))
        {
            Console.WriteLine("CPF or CRM number already exists in the collection.");
        }
        else
        {
            medicos.Add(medico1);
        }

    }
}



#endregion
*/

/* #region Relatórios

public class ReportGenerator
{
      public IEnumerable<(string Nome, int Idade)> GenerateMedicosPacientesIdadeRange(IEnumerable<Medico> medicos, IEnumerable<Paciente> pacientes, int minIdade, int maxIdade)
    {
        return medicos
            .Where(m => m.Idade >= minIdade && m.Idade <= maxIdade).Select(m => (m.Nome, m.Idade))
            .Concat(pacientes.Where(p => p.Idade >= minIdade && p.Idade <= maxIdade).Select(p => (p.Nome, p.Idade)));
    }

      public IEnumerable<(string Nome, DateTime DataNascimento)> GeneratePacientesMedicosAniversarioByMonth(IEnumerable<Paciente> pacientes, IEnumerable<Medico> medicos, int targetMonth)
    {
        return pacientes.Where(p => p.DataNascimento.Month == targetMonth).Select(p => (p.Nome, p.DataNascimento)).Concat(medicos.Where(m => m.DataNascimento.Month == targetMonth).Select(m => (m.Nome, m.DataNascimento)));
    } 
    

    public IEnumerable<object> GeneratePacientesSexoAlfabeticOrder(IEnumerable<Paciente> pacientes)
    {
        return pacientes.OrderBy(p => p.Sexo).ThenBy(p => p.Nome);
    }

}


#endregion */


 /* #region Complete Solution - Clinical Management App (v1.0)

public class Pessoa
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }

    public int Idade
    {
        get
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }
    }
}

public class Medico : Pessoa
{
    public int Crm { get; set; }
}

public class Paciente : Pessoa
{
    public string Sexo { get; set; }
    public string Sintomas { get; set; }
}

public class ReportGenerator
{
      public IEnumerable<(string Nome, int Idade)> GenerateMedicosPacientesIdadeRange(IEnumerable<Medico> medicos, IEnumerable<Paciente> pacientes, int minIdade, int maxIdade)
    {
        return medicos
            .Where(m => m.Idade >= minIdade && m.Idade <= maxIdade).Select(m => (m.Nome, m.Idade))
            .Concat(pacientes.Where(p => p.Idade >= minIdade && p.Idade <= maxIdade).Select(p => (p.Nome, p.Idade)));
    }

      public IEnumerable<(string Nome, DateTime DataNascimento)> GeneratePacientesMedicosAniversarioByMonth(IEnumerable<Paciente> pacientes, IEnumerable<Medico> medicos, int targetMonth)
    {
        return pacientes.Where(p => p.DataNascimento.Month == targetMonth).Select(p => (p.Nome, p.DataNascimento)).Concat(medicos.Where(m => m.DataNascimento.Month == targetMonth).Select(m => (m.Nome, m.DataNascimento)));
    } 
    

    public IEnumerable<object> GeneratePacientesSexoAlfabeticOrder(IEnumerable<Paciente> pacientes)
    {
        return pacientes.OrderBy(p => p.Sexo).ThenBy(p => p.Nome);
    }

}

public class Program
{
    public static void Main()
    {
        List<Paciente> pacientes = new List<Paciente>();
        List<Medico> medicos = new List<Medico>();
        ReportGenerator reportGenerator = new ReportGenerator();

        Paciente paciente1 = new Paciente()
        {
            Nome = "John Doe",
            DataNascimento = new DateTime(1980, 1, 1),
            Cpf = "12345678901",
        };

        if (pacientes.Exists(p => p.Cpf == paciente1.Cpf))
        {
            Console.WriteLine("CPF number already exists in the collection for the patient.");
        }
        else
        {
            pacientes.Add(paciente1);
        }

        Medico medico1 = new Medico()
        {
            Nome = "John Doe",
            DataNascimento = new DateTime(1980, 1, 1),
            Cpf = "12345678901",
            Crm = 12345
        };

        if (medicos.Exists(m => m.Cpf == medico1.Cpf || m.Crm == medico1.Crm))
        {
            Console.WriteLine("CPF or CRM number already exists in the collection for the doctor.");
        }
        else
        {
            medicos.Add(medico1);
        }

        var medicosPacientesIdadeRange = reportGenerator.GenerateMedicosPacientesIdadeRange(medicos, pacientes, 30, 50);

    }
}

#endregion
*/

#region Clinical Management App (v2.0 - Final Version)

using System;
using System.Collections.Generic;
using System.Linq;

public class Pessoa
{
    private string _cpf;

    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public string Cpf
    {
        get => _cpf;
        set
        {
            if (IsValidCpf(value))
            {
                _cpf = value;
            }
            else
            {
                throw new ArgumentException("Invalid CPF");
            }
        }
    }

    public int Idade
    {
        get
        {
            return DateTime.Now.Year - DataNascimento.Year;
        }
    }

    private bool IsValidCpf(string cpf)
    {
        return !string.IsNullOrEmpty(cpf);
    }
}

public class Medico : Pessoa
{
    public int Crm { get; set; }
}

public class Paciente : Pessoa
{
    public string Sexo { get; set; }
    public string Sintomas { get; set; }
}

public class ReportGenerator
{
    public IEnumerable<(string Nome, int Idade)> GenerateMedicosPacientesIdadeRange(IEnumerable<Medico> medicos, IEnumerable<Paciente> pacientes, int minIdade, int maxIdade)
    {
        return medicos.Where(m => m.Idade >= minIdade && m.Idade <= maxIdade).Select(m => (m.Nome, m.Idade)).Concat(pacientes.Where(p => p.Idade >= minIdade && p.Idade <= maxIdade).Select(p => (p.Nome, p.Idade)));
    }

    public IEnumerable<(string Nome, DateTime DataNascimento)> GeneratePacientesMedicosAniversarioByMonth(IEnumerable<Paciente> pacientes, IEnumerable<Medico> medicos, int targetMonth)
    {
        return pacientes.Where(p => p.DataNascimento.Month == targetMonth).Select(p => (p.Nome, p.DataNascimento)).Concat(medicos.Where(m => m.DataNascimento.Month == targetMonth).Select(m => (m.Nome, m.DataNascimento)));
    }

    public IEnumerable<object> GeneratePacientesSexoAlfabeticOrder(IEnumerable<Paciente> pacientes)
    {
        try
        {
            return pacientes.OrderBy(p => p.Sexo).ThenBy(p => p.Nome);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error generating report: {ex.Message}");
            return Enumerable.Empty<object>();
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<Paciente> pacientes = new List<Paciente>();
        List<Medico> medicos = new List<Medico>();
        ReportGenerator reportGenerator = new ReportGenerator();

        try
        {
            Paciente paciente1 = new Paciente()
            {
                Nome = "John Doe",
                DataNascimento = new DateTime(1980, 1, 1),
                Cpf = "12345678901",
                Sexo = "Male",
                Sintomas = "Fever",
            };

            if (pacientes.Exists(p => p.Cpf == paciente1.Cpf))
            {
                Console.WriteLine("CPF number already exists in the collection for the patient.");
            }
            else
            {
                pacientes.Add(paciente1);
            }

            Medico medico1 = new Medico()
            {
                Nome = "Jane Doe",
                DataNascimento = new DateTime(1980, 1, 1),
                Cpf = "12345678902",
                Crm = 54321
            };

            if (medicos.Exists(m => m.Cpf == medico1.Cpf || m.Crm == medico1.Crm))
            {
                Console.WriteLine("CPF or CRM number already exists in the collection for the doctor.");
            }
            else
            {
                medicos.Add(medico1);
            }

            var medicosPacientesIdadeRange = reportGenerator.GenerateMedicosPacientesIdadeRange(medicos, pacientes, 30, 50);

            Console.WriteLine("Medicos and Pacientes in Age Range:");
            foreach (var person in medicosPacientesIdadeRange)
            {
                Console.WriteLine($"Nome: {person.Nome}, Idade: {person.Idade}");
            }

            var pacientesSexoAlfabeticOrder = reportGenerator.GeneratePacientesSexoAlfabeticOrder(pacientes);

            Console.WriteLine("\nPacientes in Alphabetic Order by Sexo:");
            foreach (var paciente in pacientesSexoAlfabeticOrder)
            {
                Console.WriteLine($"Nome: {paciente.Nome}, Sexo: {paciente.Sexo}");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}



#endregion