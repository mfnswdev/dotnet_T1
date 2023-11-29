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


#region Complete Solution - Clinical Management App (final version)

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
            // Handle the case when a duplicate CPF is found for a patient
        }
        else
        {
            pacientes.Add(paciente1);
            // Continue adding the patient to the collection
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
            // Handle the case when a duplicate CPF or CRM is found for a doctor
        }
        else
        {
            medicos.Add(medico1);
            // Continue adding the doctor to the collection
        }

        // Example of using the report generator
        var medicosPacientesIdadeRange = reportGenerator.GenerateMedicosPacientesIdadeRange(medicos, pacientes, 30, 50);

        // Continue with other parts of your program
    }
}

#endregion