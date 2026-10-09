using System;

public class Figura
{
    private string _cor;

    // Construtor que aceita a cor e a define
    public Figura(string cor)
    {
        _cor = cor;
    }

    // Getter e Setter para a cor
    public string ObterCor()
    {
        return _cor;
    }

    public void DefinirCor(string cor)
    {
        _cor = cor;
    }

    // Método virtual que será sobrescrito pelas classes derivadas
    public virtual double ObterArea()
    {
        return 0;
    }
}