using System;

public class Atividade
{
    private string _data;
    private int _duracaoMinutos;

    public Atividade(string data, int duracaoMinutos)
    {
        _data = data;
        _duracaoMinutos = duracaoMinutos;
    }

    public int GetDuracaoMinutos()
    {
        return _duracaoMinutos;
    }

    // Métodos virtuais declarados na classe base (serão sobrescritos pelas filhas)
    public virtual double ObterDistancia()
    {
        return 0;
    }

    public virtual double ObterVelocidade()
    {
        return 0;
    }

    public virtual double ObterRitmo()
    {
        return 0;
    }

    // Método de resumo compartilhado por herança para todas as classes filhas
    public string ObterResumo()
    {
        string tipoAtividade = GetType().Name;
        
        // Formata as saídas numéricas com duas casas decimais
        return $"{_data} {tipoAtividade} ({_duracaoMinutos} min) — " +
               $"Distância: {ObterDistancia():0.0} km, " +
               $"Velocidade: {ObterVelocidade():0.0} km/h, " +
               $"Ritmo: {ObterRitmo():0.0} min por km";
    }
}