using System;
using System.Collections.Generic;

public class Escritura
{
    private Referencia _referencia;
    private List<Palavra> _palavras = new List<Palavra>();

    public Escritura(Referencia referencia, string texto)
    {
        _referencia = referencia;
        
        // Divide o texto por espaços e popula a lista de objetos Palavra
        string[] palavrasDivididas = texto.Split(' ');
        foreach (string textoPalavra in palavrasDivididas)
        {
            _palavras.Add(new Palavra(textoPalavra));
        }
    }

    public void OcultarPalavrasAleatorias(int quantidadeParaOcultar)
    {
        Random random = new Random();

        // Desafio Adicional / Criatividade: Cria uma lista contendo APENAS os índices de palavras visíveis
        List<int> indicesDisponiveis = new List<int>();
        for (int i = 0; i < _palavras.Count; i++)
        {
            if (!_palavras[i].EstaOculta())
            {
                indicesDisponiveis.Add(i);
            }
        }

        // Determina quantas palavras de fato podemos ocultar nesta rodada
        int totalRealParaOcultar = Math.Min(quantidadeParaOcultar, indicesDisponiveis.Count);

        for (int i = 0; i < totalRealParaOcultar; i++)
        {
            int indiceAleatorio = random.Next(indicesDisponiveis.Count);
            int indicePalavraAlvo = indicesDisponiveis[indiceAleatorio];

            _palavras[indicePalavraAlvo].Ocultar();
            indicesDisponiveis.RemoveAt(indiceAleatorio); // Remove para não sortear o mesmo índice de novo
        }
    }

    public string ObterTextoExibicao()
    {
        List<string> listaTextos = new List<string>();
        foreach (Palavra palavra in _palavras)
        {
            listaTextos.Add(palavra.ObterTextoExibicao());
        }

        return $"{_referencia.ObterTextoExibicao()} — {string.Join(" ", listaTextos)}";
    }

    public bool EstaCompletamenteOculta()
    {
        foreach (Palavra palavra in _palavras)
        {
            if (!palavra.EstaOculta())
            {
                return false;
            }
        }
        return true;
    }
}