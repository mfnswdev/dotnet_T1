#region PRATICA P003 - Aplicação de Gerenciamento de Estoques

using System;
using System.Collections.Generic;
using System.Linq;

public record Produto(int Codigo, string Nome, int Quantidade, double Preco);

class Program
{
    static void Main()
    {
        List<Produto> estoque = new List<Produto>();

        try
        {
            while (true)
            {
                Console.WriteLine("1. Cadastrar Produto");
                Console.WriteLine("2. Consultar Produto");
                Console.WriteLine("3. Atualizar Estoque");
                Console.WriteLine("4. Relatórios");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");

                if (!int.TryParse(Console.ReadLine(), out int escolha))
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    continue;
                }

                switch (escolha)
                {
                    case 1:
                        CadastrarProduto(estoque);
                        break;
                    case 2:
                        ConsultarProduto(estoque);
                        break;
                    case 3:
                        AtualizarEstoque(estoque);
                        break;
                    case 4:
                        GerarRelatorios(estoque);
                        break;
                    case 5:
                        Console.WriteLine("Saindo do programa.");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    static void CadastrarProduto(List<Produto> estoque)
    {
        Console.Write("Código: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine());

        var novoProduto = new Produto(codigo, nome, quantidade, preco);

        if (estoque.Any(p => p.Codigo == codigo))
        {
            throw new Exception("Produto com código já cadastrado.");
        }

        estoque.Add(novoProduto);
        Console.WriteLine($"Produto '{novoProduto.Nome}' cadastrado com sucesso.");
    }

    static void ConsultarProduto(List<Produto> estoque)
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());

        var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

        if (produto == null)
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
        }

        Console.WriteLine($"Produto encontrado: {produto.Codigo} - {produto.Nome} - Quantidade: {produto.Quantidade} - Preço: {produto.Preco:C}");
    }

    static void AtualizarEstoque(List<Produto> estoque)
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine());

        var produto = estoque.FirstOrDefault(p => p.Codigo == codigo);

        if (produto == null)
        {
            throw new ProdutoNaoEncontradoException($"Produto com código {codigo} não encontrado.");
        }

        Console.Write("Digite a quantidade a ser adicionada (positiva) ou removida (negativa): ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("Digite 'E' para entrada ou 'S' para saída: ");
        char operacao = Console.ReadLine().ToUpper()[0];

        if (operacao != 'E' && operacao != 'S')
        {
            Console.WriteLine("Operação inválida. Tente novamente.");
            return;
        }

        if (operacao == 'S' && produto.Quantidade < quantidade)
        {
            throw new EstoqueInsuficienteException($"Estoque insuficiente para a saída do produto {codigo}.");
        }

        if (operacao == 'E')
        {
            produto = produto with { Quantidade = produto.Quantidade + quantidade };
        }
        else
        {
            produto = produto with { Quantidade = produto.Quantidade - quantidade };
        }

        estoque[estoque.FindIndex(p => p.Codigo == codigo)] = produto;
        Console.WriteLine($"Estoque atualizado: {produto.Codigo} - {produto.Nome} - Nova quantidade: {produto.Quantidade}");
    }

    static void GerarRelatorios(List<Produto> estoque)
    {
        Console.Write("1. Lista de produtos com quantidade em estoque abaixo de um limite\n" +
                      "2. Lista de produtos com valor entre um mínimo e um máximo\n" +
                      "3. Informar o valor total do estoque e o valor total de cada produto\n" +
                      "Escolha uma opção: ");

        if (!int.TryParse(Console.ReadLine(), out int escolha))
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
            return;
        }

        switch (escolha)
        {
            case 1:
                Console.Write("Digite o limite de quantidade: ");
                int limite = int.Parse(Console.ReadLine());
                RelatorioEstoqueMinimo(estoque, limite);
                break;
            case 2:
                Console.Write("Digite o valor mínimo: ");
                double min = double.Parse(Console.ReadLine());

                Console.Write("Digite o valor máximo: ");
                double max = double.Parse(Console.ReadLine());

                RelatorioValorProdutos(estoque, min, max);
                break;
            case 3:
                RelatorioValorTotalEstoque(estoque);
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void RelatorioEstoqueMinimo(List<Produto> estoque, int limite)
    {
        var produtosAbaixoDoLimite = estoque.Where(p => p.Quantidade < limite);

        Console.WriteLine($"Produtos com quantidade em estoque abaixo de {limite}:");
        foreach (var produto in produtosAbaixoDoLimite)
        {
            Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Quantidade: {produto.Quantidade}");
        }
    }

    static void RelatorioValorProdutos(List<Produto> estoque, double min, double max)
    {
        var produtosNoIntervalo = estoque.Where(p => p.Preco >= min && p.Preco <= max);

        Console.WriteLine($"Produtos com valor entre {min:C} e {max:C}:");
        foreach (var produto in produtosNoIntervalo)
        {
            Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Preço: {produto.Preco:C}");
        }
    }

    static void RelatorioValorTotalEstoque(List<Produto> estoque)
    {
        double valorTotalEstoque = estoque.Sum(p => p.Quantidade * p.Preco);

        Console.WriteLine($"Valor total do estoque: {valorTotalEstoque:C}");

        Console.WriteLine("Valor total por produto:");
        foreach (var produto in estoque)
        {
            double valorTotalProduto = produto.Quantidade * produto.Preco;
            Console.WriteLine($"{produto.Codigo} - {produto.Nome} - Valor total: {valorTotalProduto:C}");
        }
    }
}

class ProdutoNaoEncontradoException : Exception
{
    public ProdutoNaoEncontradoException(string message) : base(message)
    {
    }
}

class EstoqueInsuficienteException : Exception
{
    public EstoqueInsuficienteException(string message) : base(message)
    {
    }
}


#endregion