using System;

public class AtividadeRespiracao : Atividade
{
    public AtividadeRespiracao() : base(
        "Atividade de Respiração", 
        "Esta atividade ajudará você a relaxar, inspirando e expirando lentamente. Limpe sua mente e concentre-se na sua respiração.")
    {
    }

    public void Executar()
    {
        ExibirMensagemInicial();
        
        DateTime tempoFinal = DateTime.Now.AddSeconds(GetDuracao());

        // Alterna entre inspirar e expirar de forma controlada até o fim do tempo
        while (DateTime.Now < tempoFinal)
        {
            Console.Write("\nInspire...");
            ExibirContagemRegressiva(4);
            Console.WriteLine();

            Console.Write("Expire...");
            ExibirContagemRegressiva(6);
            Console.WriteLine();
        }

        ExibirMensagemFinal();
    }
}