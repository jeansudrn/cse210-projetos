using System;

public class Quadrado : Figura
{
    private double _lado;

    // Construtor chama o construtor base passando a cor
    public Quadrado(string cor, double lado) : base(cor)
    {
        _lado = lado;
    }

    // Sobrescreve o método virtual da classe base
    public override double ObterArea()
    {
        return _lado * _lado;
    }
}