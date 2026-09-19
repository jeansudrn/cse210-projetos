using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criando uma biblioteca de escrituras variadas para demonstrar criatividade
        List<Escritura> biblioteca = new List<Escritura>()
        {
            new Escritura(new Referencia("Provérbios", 3, 5, 6), "Confia no Senhor de todo o teu coração e não te estribes no teu próprio entendimento."),
            new Escritura(new Referencia("João", 3, 16), "Porque Deus amou o mundo de tal maneira que deu o seu Filho Unigênito."),
            new Escritura(new Referencia("Filipenses", 4, 13), "Posso todas as coisas naquele que me fortalece."),
            new Escritura(new Referencia("1 Néfi", 3, 7), "Eu irei e cumprirei as ordens que o Senhor deu.")
        };

        // Escolhe uma escritura aleatória da biblioteca
        Random random = new Random();
        Escritura escrituraSelecionada = biblioteca[random.Next(biblioteca.Count)];

        string entradaUsuario = "";

        // Loop principal do programa
        while (entradaUsuario.ToLower() != "sair" && !escrituraSelecionada.EstaCompletamenteOculta())
        {
            Console.Clear(); // Limpa o console a cada rodada conforme a especificação
            Console.WriteLine(escrituraSelecionada.ObterTextoExibicao());
            Console.WriteLine("\nPressione Enter para ocultar palavras ou digite 'sair' para encerrar:");
            
            entradaUsuario = Console.ReadLine();

            if (entradaUsuario.ToLower() != "sair")
            {
                escrituraSelecionada.OcultarPalavrasAleatorias(3); // Oculta 3 palavras por vez
            }
        }

        // Exibição final obrigatória com o texto 100% ocultado se o usuário não desistiu
        if (escrituraSelecionada.EstaCompletamenteOculta())
        {
            Console.Clear();
            Console.WriteLine(escrituraSelecionada.ObterTextoExibicao());
            Console.WriteLine("\nParabéns! Você ocultou todas as palavras da escritura.");
        }
    }
}