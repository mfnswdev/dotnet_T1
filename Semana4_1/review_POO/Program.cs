/* #region Exercicio 1

public class Veiculo
{
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }
}

public class Program
{
    public static void Main()
    {
        Veiculo meuVeiculo = new Veiculo();

        meuVeiculo.Modelo = "Honda Civic";
        meuVeiculo.Cor = "Vermelho";
        meuVeiculo.Ano = 2013;

        Console.WriteLine("Ficha tecnica do meu veiculo:");
        Console.WriteLine($"Modelo: {meuVeiculo.Modelo}");
        Console.WriteLine($"Cor: {meuVeiculo.Cor}");
        Console.WriteLine($"Ano: {meuVeiculo.Ano}");
    }
}
#endregion
*/

/* #region Exercicio 2 

public class Veiculo
{
    public string Modelo { get; set; }
    public string Cor { get; set; }
    public int Ano { get; set; }

    public int IdadeVeiculo
    {
        get
        {
            int anoAtual = DateTime.Now.Year;
            return anoAtual - Ano;
        }
    }
}

public class Program
{
    public static void Main()
    {
        Veiculo meuVeiculo = new Veiculo();

        meuVeiculo.Modelo = "Honda Civic";
        meuVeiculo.Cor = "Vermelho";
        meuVeiculo.Ano = 2013;

        Console.WriteLine("Ficha tecnica do meu veiculo:");
        Console.WriteLine($"Modelo: {meuVeiculo.Modelo}");
        Console.WriteLine($"Cor: {meuVeiculo.Cor}");
        Console.WriteLine($"Ano: {meuVeiculo.Ano}");
        Console.WriteLine($"Idade do veiculo: {meuVeiculo.IdadeVeiculo} anos");
    }
}

#endregion
*/

/* #region Exercicio 3

public class ContaBancaria
{
    private decimal saldo;

    public decimal Saldo
    {
        get { return saldo; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Saldo nao pode ser negativo");
            }
            saldo = value;
        }
    }
}

public class Program
{
    public static void Main()
    {
        ContaBancaria conta = new ContaBancaria();

        try
        {
            conta.Saldo = -100;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

#endregion
*/

/* #region Exercicio 4 

public class Aluno
{
    public string Nome { get; set; }
    public int Idade { get; set; }

    public Aluno()
    {
        Nome = "Sem_Nome";
        Idade = 0;
    }
}

public class Program
{
    public static void Main()
    {
        Aluno aluno = new Aluno();
        Console.WriteLine($"Nome: {aluno.Nome}");
        Console.WriteLine($"Idade: {aluno.Idade}");
    }
}

#endregion
*/