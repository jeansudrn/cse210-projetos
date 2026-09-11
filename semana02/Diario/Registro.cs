using System;

public class Registro
{
    private string _data;
    private string _textoPergunta;
    private string _textoRegistro;

    // Construtor
    public Registro(string data, string textoPergunta, string textoRegistro)
    {
        _data = data;
        _textoPergunta = textoPergunta;
        _textoRegistro = textoRegistro;
    }

    // Exibe a entrada formatada na tela para o usuário
    public void Exibir()
    {
        Console.WriteLine($"Data: {_data} — Pergunta: {_textoPergunta}");
        Console.WriteLine($"{_textoRegistro}");
        Console.WriteLine(new string('-', 40));
    }

    // Formata os dados internos em texto simples separado por delimitador para persistência
    public string FormatarParaArquivo()
    {
        return $"{_data} | {_textoPergunta} | {_textoRegistro}";
    }
}