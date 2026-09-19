using System;

public class Referencia
{
    private string _livro;
    private int _capitulo;
    private int _versiculoInicio;
    private int _versiculoFinal;

    // Construtor 1: Versículo único (ex: João 3:16)
    public Referencia(string livro, int capitulo, int versiculo)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicio = versiculo;
        _versiculoFinal = versiculo;
    }

    // Construtor 2: Intervalo de versículos (ex: Provérbios 3:5-6)
    public Referencia(string livro, int capitulo, int versiculoInicio, int versiculoFinal)
    {
        _livro = livro;
        _capitulo = capitulo;
        _versiculoInicio = versiculoInicio;
        _versiculoFinal = versiculoFinal;
    }

    public string ObterTextoExibicao()
    {
        if (_versiculoInicio == _versiculoFinal)
        {
            return $"{_livro} {_capitulo}:{_versiculoInicio}";
        }
        return $"{_livro} {_capitulo}:{_versiculoInicio}-{_versiculoFinal}";
    }
}