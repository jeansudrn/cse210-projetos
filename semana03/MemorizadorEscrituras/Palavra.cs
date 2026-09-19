using System;

public class Palavra
{
    private string _texto;
    private bool _estaOculta;

    // Construtor: define a palavra inicialmente como visível
    public Palavra(string texto)
    {
        _texto = texto;
        _estaOculta = false;
    }

    public void Ocultar()
    {
        _estaOculta = true;
    }

    public bool EstaOculta()
    {
        return _estaOculta;
    }

    // Retorna o texto original ou sublinhados equivalentes ao tamanho da palavra
    public string ObterTextoExibicao()
    {
        if (_estaOculta)
        {
            return new string('_', _texto.Length);
        }
        return _texto;
    }
}