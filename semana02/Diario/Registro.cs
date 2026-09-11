using System;

public class Registro
{
    private string _data;
    private string _textoPergunta;
    private string _textoRegistro;

    public Registro(string data, string textoPergunta, string textoRegistro)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoRegistro = textoRegistro;
    }

    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} — Pergunta: {_textoPergunta}");
        Console.WriteLine($"{_textoRegistro}");
        Console.WriteLine(new string('-', 40));
    }

    public string FormatarParaArquivo()
    {
        return $"{_data} | {_textoPergunta} | {_textoRegistro}";
    }

    // Método auxiliar para o critério 10 (Criatividade)
    public bool ContemPalavraChave(string palavraChave)
    {
        return _textoRegistro.Contains(palavraChave, StringComparison.OrdinalIgnoreCase) || 
               _textoPergunta.Contains(palavraChave, StringComparison.OrdinalIgnoreCase);
    }
}