using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    private List<string> _perguntas = new List<string>()
    {
        "Quem foi a pessoa mais interessante com quem conversei hoje?",
        "Qual foi a melhor parte do meu dia?",
        "Como eu vi a mão do Senhor na minha vida hoje?",
        "Qual foi a emoção mais forte que senti hoje?",
        "Se eu pudesse fazer uma coisa diferente hoje, o que seria?",
        "O que fiz hoje que me deixou mais próximo dos meus objetivos?"
    };

    // Sorteia e retorna uma pergunta aleatória
    public string ObterPerguntaAleatoria()
    {
        Random random = new Random();
        int indice = random.Next(_perguntas.Count);
        return _perguntas[indice];
    }
}