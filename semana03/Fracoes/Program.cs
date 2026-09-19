using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--- Testando os Construtores e Representações ---\n");

        // Teste 1: Usando o primeiro construtor (Sem parâmetros -> 1/1)
        Fracao f1 = new Fracao();
        Console.WriteLine(f1.ObterFracaoEmTexto());
        Console.WriteLine(f1.ObterFracaoEmDecimal());
        Console.WriteLine();

        // Teste 2: Usando o segundo construtor (Apenas numerador -> 5/1)
        Fracao f2 = new Fracao(5);
        Console.WriteLine(f2.ObterFracaoEmTexto());
        Console.WriteLine(f2.ObterFracaoEmDecimal());
        Console.WriteLine();

        // Teste 3: Usando o terceiro construtor (Dois parâmetros -> 3/4)
        Fracao f3 = new Fracao(3, 4);
        Console.WriteLine(f3.ObterFracaoEmTexto());
        Console.WriteLine(f3.ObterFracaoEmDecimal());
        Console.WriteLine();

        // Teste 4: Usando o terceiro construtor novamente (Dois parâmetros -> 1/3)
        Fracao f4 = new Fracao(1, 3);
        Console.WriteLine(f4.ObterFracaoEmTexto());
        Console.WriteLine(f4.ObterFracaoEmDecimal());
        Console.WriteLine();

        Console.WriteLine("--- Testando Getters e Setters ---");
        // Criando uma fração e alterando seus valores manualmente usando os Setters
        Fracao fTeste = new Fracao();
        fTeste.SetNumerador(6);
        fTeste.SetDenominador(7);

        // Recuperando os valores individualmente usando os Getters
        Console.WriteLine($"Novo Numerador: {fTeste.GetNumerador()}");
        Console.WriteLine($"Novo Denominador: {fTeste.GetDenominador()}");
        Console.WriteLine($"Resultado alterado: {fTeste.ObterFracaoEmTexto()}");
    }
}