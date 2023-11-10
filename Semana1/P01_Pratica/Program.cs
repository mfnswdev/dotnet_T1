#region Dados numéricos tipo int no C#(.net)
        int exemploInt = 42;
        Console.WriteLine($"Exemplo int: {exemploInt}");
        long exemploLong = 1234567890123456;
        Console.WriteLine($"Exemplo long: {exemploLong}");
        short exemploShort = 32767;
        Console.WriteLine($"Exemplo short: {exemploShort}");
        byte exemploByte = 255;
        Console.WriteLine($"Exemplo byte: {exemploByte}");
        sbyte exemploSByte = -128;
        Console.WriteLine($"Exemplo sbyte: {exemploSByte}");
        ushort exemploUShort = 65535;
        Console.WriteLine($"Exemplo ushort: {exemploUShort}");
        uint exemploUInt = 4294967295;
        Console.WriteLine($"Exemplo uint: {exemploUInt}");
        ulong exemploULong = 18446744073709551615;
        Console.WriteLine($"Exemplo ulong: {exemploULong}");
#endregion

#region Conversão de dados double em int
double numeroDouble = 9.37;
        int numeroInteiro;

        numeroInteiro = (int)numeroDouble;
        Console.WriteLine("Número double: " + numeroDouble);
        Console.WriteLine("Número inteiro depois da conversão: " + numeroInteiro);

#endregion

#region Operadores aritiméticos
    int x = 10;
    int y = 3;
        int soma = x + y;
        int subtracao = x - y;
        int multiplicacao = x * y;
        int divisao = x / y;
    Console.WriteLine($"Adição: {soma}");
    Console.WriteLine($"Subtração: {subtracao}");
    Console.WriteLine($"Multiplicação: {multiplicacao}");
    Console.WriteLine($"Divisão: {divisao}");
#endregion

#region Operadores de comparação
    int a = 5;
    int b = 8;
    string comparacao = a > b ? "Valor de A é maior que B" : "Valor de B é maior que A";

    Console.WriteLine(comparacao);

#endregion

#region Operador de igualdade
    string str1 = "hello";
    string str2 = "world";
    string compare;
        compare = str1 == str2 ? "São iguais" : "Não são iguais";
        Console.WriteLine(compare);
#endregion

#region Operador lógico
    bool condicao1 = true;
    bool condicao2 = false;
    string result1;

        result1 = (condicao1 && condicao2) ? "Ambos são verdadeiros." : "Pelo menos uma das condições é falsa.";
        Console.WriteLine(result1);
#endregion

#region Mix de Operadores
    int num1 = 7;
    int num2 = 3;
    int num3 = 10;
        bool verifica1;
        bool verifica2;

            verifica1 = (num1 > num2) ? true : false;
            Console.WriteLine(verifica1);
            verifica2 = (num3 == (num1+num2)) ? true : false;
            Console.WriteLine(verifica2);
#endregion