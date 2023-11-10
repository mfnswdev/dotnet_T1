#region Dados numéricos tipo int no C#(.net)
        
        int exemploInt = 42;
        Console.WriteLine($"Exemplo int: {exemploInt}");

        // 2. long: Representa números inteiros de 64 bits
        long exemploLong = 1234567890123456;
        Console.WriteLine($"Exemplo long: {exemploLong}");

        // 3. short: Representa números inteiros de 16 bits
        short exemploShort = 32767;
        Console.WriteLine($"Exemplo short: {exemploShort}");

        // 4. byte: Representa números inteiros de 8 bits
        byte exemploByte = 255;
        Console.WriteLine($"Exemplo byte: {exemploByte}");

        // 5. sbyte: Representa números inteiros de 8 bits com sinal
        sbyte exemploSByte = -128;
        Console.WriteLine($"Exemplo sbyte: {exemploSByte}");

        // 6. ushort: Representa números inteiros sem sinal de 16 bits
        ushort exemploUShort = 65535;
        Console.WriteLine($"Exemplo ushort: {exemploUShort}");

        // 7. uint: Representa números inteiros sem sinal de 32 bits
        uint exemploUInt = 4294967295;
        Console.WriteLine($"Exemplo uint: {exemploUInt}");

        // 8. ulong: Representa números inteiros sem sinal de 64 bits
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