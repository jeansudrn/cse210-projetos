using System;

public class Ciclismo : Atividade
{
    private double _velocidadeKmh;

    public Ciclismo(string data, int duracaoMinutos, double velocidadeKmh) : base(data, duracaoMinutos)
    {
        _velocidadeKmh = velocidadeKmh;
    }

    public override double ObterDistancia()
    {
        // Distância = (velocidade * minutos) / 60
        return (_velocidadeKmh * GetDuracaoMinutos()) / 60;
    }

    public override double ObterVelocidade()
    {
        return _velocidadeKmh;
    }

    public override double ObterRitmo()
    {
        // Ritmo = 60 / velocidade
        return 60 / _velocidadeKmh;
    }
}