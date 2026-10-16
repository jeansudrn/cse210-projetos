using System;

public class Natacao : Atividade
{
    private int _numeroVoltas;

    public Natacao(string data, int duracaoMinutos, int numeroVoltas) : base(data, duracaoMinutos)
    {
        _numeroVoltas = numeroVoltas;
    }

    public override double ObterDistancia()
    {
        // Distância (km) = voltas de natação * 50 / 1000
        return (_numeroVoltas * 50.0) / 1000.0;
    }

    public override double ObterVelocidade()
    {
        // Velocidade (km/h) = (distância / minutos) * 60
        return (ObterDistancia() / GetDuracaoMinutos()) * 60;
    }

    public override double ObterRitmo()
    {
        // Ritmo (min por km) = minutos / distância
        return GetDuracaoMinutos() / ObterDistancia();
    }
}