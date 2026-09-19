using System;

public class Fracao
{
    // Atributos privados (Encapsulamento)
    private int _numerador;
    private int _denominador;

    // 1. Construtor padrão sem parâmetros: inicializa como 1/1
    public Fracao()
    {
        _numerador = 1;
        _denominador = 1;
    }

    // 2. Construtor com um parâmetro (numerador): inicializa o denominador como 1
    public Fracao(int numeroInteiro)
    {
        _numerador = numeroInteiro;
        _denominador = 1;
    }

    // 3. Construtor com dois parâmetros: numerador e denominador
    public Fracao(int numerador, int denominador)
    {
        _numerador = numerador;
        _denominador = denominador;
    }

    // Getters e Setters para o Numerador
    public int GetNumerador()
    {
        return _numerador;
    }

    public void SetNumerador(int numerador)
    {
        _numerador = numerador;
    }

    // Getters e Setters para o Denominador
    public int GetDenominador()
    {
        return _denominador;
    }

    public void SetDenominador(int denominador)
    {
        // Validação simples para evitar divisão por zero
        if (denominador == 0)
        {
            Console.WriteLine("Erro: O denominador não pode ser zero. Mantendo o valor atual.");
            return;
        }
        _denominador = denominador;
    }

    // Método que retorna a representação textual (ex: "3/4")
    public string ObterFracaoEmTexto()
    {
        return $"{_numerador}/{_denominador}";
    }

    // Método que calcula e retorna o valor decimal (ex: 0.75)
    public double ObterFracaoEmDecimal()
    {
        // É necessário converter pelo menos um dos números para double 
        // para que o C# não faça uma divisão inteira (que cortaria os decimais).
        return (double)_numerador / _denominador;
    }
}