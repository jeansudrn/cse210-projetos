using System;
using System.Collections.Generic;

public class AtividadeReflexao : Atividade
{
    private List<string> _mensagensPrompts = new List<string>
    {
        "Pense em uma ocasião em que você defendeu outra pessoa.",
        "Pense em uma ocasião em que você fez algo realmente difícil.",
        "Pense em uma ocasião em que você ajudou alguém necessitado.",
        "Pense em uma ocasião em que você fez algo verdadeiramente altruísta."
    };

    private List<string> _perguntasReflexao = new List<string>
    {
        "Por que essa experiência foi significativa para você?",
        "Você já fez algo assim antes?",
        "Como você começou?",
        "Como você se felt quando terminou?",
        "O que tornou esse momento diferente de outras vezes em que você não teve tanto sucesso?",
        "Qual é a sua coisa favorita sobre essa experiência?",
        "O que você pode aprender com essa experiência que se aplica a outras situações?",
        "O que você aprendeu sobre si mesmo por meio dessa experiência?",
        "Como você pode manter essa experiência em mente no futuro?"
    };

    public AtividadeReflexao() : base(
        "Atividade de Reflexão",
        "Esta atividade ajudará você a refletir sobre momentos da sua vida em que você demonstrou força e resiliência. Isso ajudará você a reconhecer o poder que você tem e como pode usá-lo em outros aspectos da sua vida.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Random random = new Random();
        
        // Exibe um prompt de situação inicial aleatório
        int indicePrompt = random.Next(_mensagensPrompts.Count);
        Console.WriteLine("Considere a seguinte instrução:\n");
        Console.WriteLine($"--- {_mensagensPrompts[indicePrompt]} ---\n");
        Console.WriteLine("Quando você tiver algo em mente, pressione ENTER para continuar.");
        Console.ReadLine();

        Console.WriteLine("Agora, reflita sobre cada uma das seguintes questões em relação à sua experiência:");
        Console.Write("Você começará em: ");
        ExibirContagemRegressiva(5);
        Console.Clear();

        DateTime tempoFinal = DateTime.Now.AddSeconds(GetDuracao());
        
        // Clonagem da lista para controle de criatividade (evitar repetições imediatas)
        List<string> listaPerguntasDisponiveis = new List<string>(_perguntasReflexao);

        while (DateTime.Now < tempoFinal)
        {
            // Se as perguntas acabarem antes do tempo acabar, recarrega a lista
            if (listaPerguntasDisponiveis.Count == 0)
            {
                listaPerguntasDisponiveis = new List<string>(_perguntasReflexao);
            }

            int indiceAleatorio = random.Next(listaPerguntasDisponiveis.Count);
            string perguntaSelecionada = listaPerguntasDisponiveis[indiceAleatorio];

            Console.Write($"\n> {perguntaSelecionada} ");
            ExibirAnimacaoSpinner(5); // Pausa exibindo o spinner de progresso visual
            Console.WriteLine();

            // Remoção para garantir originalidade (Demonstração de Criatividade)
            listaPerguntasDisponiveis.RemoveAt(indiceAleatorio);
        }

        ExibirMensagemFinal();
    }
}
