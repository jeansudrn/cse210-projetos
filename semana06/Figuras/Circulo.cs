using System;

public class Circulo : Figura
{
    private double _raio;

    public Circulo(string cor, double raio) : base(cor)
    {
        _raio = raio;
    }

    public override double ObterArea()
    {
        // Fórmula da área do círculo: pi * raio^2
        return Math.PI * (_raio * _raio);
    }
}