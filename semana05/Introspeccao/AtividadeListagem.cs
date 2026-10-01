using System;
using System.Collections.Generic;

public class AtividadeListagem : Atividade
{
    private List<string> _promptsListagem = new List<string>
    {
        "Quem são as pessoas que você aprecia?",
        "Quais são seus pontos fortes pessoais?",
        "Quem são as pessoas que você ajudou esta semana?",
        "Quando você sentiu o Espírito Santo neste mês?",
        "Quem são alguns dos seus heróis pessoais?"
    };

    public AtividadeListagem() : base(
        "Atividade de Listagem",
        "Esta atividade ajudará você a refletir sobre as coisas boas da sua vida, fazendo com que você liste o máximo de coisas que puder em uma determinada área.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();

        Random random = new Random();
        int indicePrompt = random.Next(_promptsListagem.Count);

        Console.WriteLine("Liste o máximo de coisas que puder em relação à seguinte instrução:");
        Console.WriteLine($"--- {_promptsListagem[indicePrompt]} ---\n");
        Console.Write("Você pode começar a pensar em: ");
        ExibirContagemRegressiva(5);
        Console.WriteLine("\nComece a listar seus itens (Pressione ENTER após cada um):");

        int contadorItens = 0;
        DateTime tempoFinal = DateTime.Now.AddSeconds(GetDuracao());

        // Captura as strings inseridas pelo usuário até que o tempo expire
        while (DateTime.Now < tempoFinal)
        {
            // Verifica se há entrada disponível no console sem bloquear completamente caso o tempo acabe
            if (Console.KeyAvailable)
            {
                string item = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(item))
                {
                    contadorItens++;
                }
            }
        }

        Console.WriteLine($"\nMuito bem! Você listou {contadorItens} itens!");
        ExibirMensagemFinal();
    }
}