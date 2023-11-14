/*
#region Exemplo função foreach

string[] colecao= {"Item1", "Item2", "Item3", "Item4"};

foreach (string item in colecao)
{
    Console.WriteLine(item);
}

#endregion

#region Exemplo ReadLine

Console.WriteLine("Por favor, informe seu nome:");
string? nome = Console.ReadLine();   
Console.WriteLine($"Olá, {nome}!");

#endregion

#region Exercício laços e repetições, Questão 01.

int num;

for (num = 0; num <= 30; num++){
    if (num%3==0 || num%4==0){
        Console.WriteLine(num);
    }
}

#endregion

#region Questão 02.


#endregion

#region Exemplos de métodos, propriedades e campos para Strings

Console.WriteLine("Por favor, informe seu nome:");
string? nome = Console.ReadLine();   


Console.WriteLine($"Hello, {nome.ToUpper()}!");
Console.WriteLine($"Hello, {nome});
Console.WriteLine($"Tamanho, {nome.length}");

string[] nomeSplited = nome.Split(' ');
foreach (string nomePart in nomeSplited){
    Console.WriteLine()
}

#endregion

*/
#region Exemplos de Listas

List<int> numbers = new List<int>();
numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);

Console.WriteLine("Lista de int:");
foreach(int number in numbers){
    Console.WriteLine(number);
}

List<String> names = new List<string>();
names.Add("Alice");
names.Add("Pedro");
names.Add("Chagas");
names.Add("Maria");
names.Add("Fulano");

Console.WriteLine("Lista de Strings:");
foreach (String name in names){
    Console.WriteLine(name);
}

//Lista de listas TriDimensional
Console.WriteLine("Lista de Strings II:");
List<List<string>> names2 = new List<List<string>>()
{
    new List<string>() { "Alice", "Pedro", "Chagas", "Maria", "Fulano" },
    new List<string>() { "Alberto", "Allana", "Álvaro" },
    new List<string>() { "Biancardy", "Bruno", "Bárbara" }
};

for (int i = 0; i < names2.Count; i++)
{
    Console.WriteLine(names2);
}

#endregion

#region Exemplo DateTime

#endregion

#region Lista de Datas



#endregion