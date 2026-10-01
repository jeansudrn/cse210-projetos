using System;
using System.Collections.Generic;

public class Video
{
    // Atributos privados (Variáveis membro em _underscoreCamelCase)
    private string _titulo;
    private string _autor;
    private int _duracaoEmSegundos;
    private List<Comentario> _comentarios;

    // Construtor: Inicializa o estado do objeto e a lista dinâmica
    public Video(string titulo, string autor, int duracaoEmSegundos)
    {
        _titulo = titulo;
        _autor = autor;
        _duracaoEmSegundos = duracaoEmSegundos;
        _comentarios = new List<Comentario>();
    }

    // Métodos de Comportamento (TitleCase)
    public void AdicionarComentario(Comentario comentario)
    {
        _comentarios.Add(comentario);
    }

    public int ObterQuantidadeDeComentarios()
    {
        return _comentarios.Count;
    }

    // Getters públicos para acesso seguro externo
    public string GetTitulo()
    {
        return _titulo;
    }

    public string GetAutor()
    {
        return _autor;
    }

    public int GetDuracao()
    {
        return _duracaoEmSegundos;
    }

    public List<Comentario> ObterComentarios()
    {
        return _comentarios;
    }
}