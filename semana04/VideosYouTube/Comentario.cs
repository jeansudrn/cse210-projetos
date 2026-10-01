using System;

public class Comentario
{
    // Atributos privados (Encapsulamento)
    private string _nomeDoUsuario;
    private string _texto;

    // Construtor
    public Comentario(string nomeDoUsuario, string texto)
    {
        _nomeDoUsuario = nomeDoUsuario;
        _texto = texto;
    }

    // Getters públicos para exibição segura dos dados no fluxo principal
    public string GetNomeDoUsuario()
    {
        return _nomeDoUsuario;
    }

    public string GetTexto()
    {
        return _texto;
    }
}