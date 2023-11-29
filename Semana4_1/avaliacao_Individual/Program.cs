﻿using System;
using System.Collections.Generic;

/*
#region Classes
public class Medico
{
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public double Cpf { get; set; }
    public int Crm { get; set; }
}

public class Paciente
{
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public double Cpf { get; set; }
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

        // Check if the new medico's CPF or CRM already exist in the collection
        if (medicos.Exists(m => m.Cpf == medico1.Cpf || m.Crm == medico1.Crm))
        {
            Console.WriteLine("CPF or CRM number already exists in the collection.");
            // Handle the case when a duplicate CPF or CRM is found
        }
        else
        {
            medicos.Add(medico1);
            // Continue adding the medico to the collection
        }

    }
}



#endregion

*/



#region Relatórios
public class Medico
{
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public double Cpf { get; set; }
    public int Crm { get; set; }
}

public class Paciente
{
    public string Nome { get; set; }
    public string DataNascimento { get; set; }
    public double Cpf { get; set; }
    public string Sexo { get; set; }
    public string Sintomas { get; set; }
}

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

        // Check if the new medico's CPF or CRM already exist in the collection
        if (medicos.Exists(m => m.Cpf == medico1.Cpf || m.Crm == medico1.Crm))
        {
            Console.WriteLine("CPF or CRM number already exists in the collection.");
            // Handle the case when a duplicate CPF or CRM is found
        }
        else
        {
            medicos.Add(medico1);
            // Continue adding the medico to the collection
        }

    }
}

namespace YourNamespace
{
    public class YourClassName
    {
        // Report of Medicos and Pacientes between idade range
        var medicosPacientesIdadeRange = medicos.Where(m => m.Idade >= minIdade && m.Idade <= maxIdade).Concat(pacientes.Where(p => p.Idade >= minIdade && p.Idade <= maxIdade));

        // Report of Pacientes using sexo as reference and in alfabetic order
        var pacientesSexoAlfabeticOrder = pacientes.OrderBy(p => p.Sexo).ThenBy(p => p.Nome);

        // Report of Pacientes and Medicos with aniversary by month
        var pacientesMedicosAniversarioByMonth = pacientes.Where(p => p.DataNascimento.Month == targetMonth).Concat(medicos.Where(m => m.DataNascimento.Month == targetMonth));
    }
}


#endregion