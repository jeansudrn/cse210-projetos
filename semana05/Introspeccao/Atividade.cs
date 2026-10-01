using System;
using System.Collections.Generic;
using System.Threading;

public class Atividade
{
    private string _nome;
    private string _descricao;
    private int _duracao;

    public Atividade(string nome, string descricao)
    {
        _nome = nome;
        _descricao = descricao;
    }

    public int GetDuracao()
    {
        return _duracao;
    }

    // Exibe as mensagens padronizadas de abertura para todas as atividades filhas
    public void ExibirMensagemInicial()
    {
        Console.Clear();
        Console.WriteLine($"Bem-vindo à {_nome}.\n");
        Console.WriteLine($"{_descricao}\n");
        Console.Write("Quanto tempo, em segundos, você gostaria para a sua sessão? ");
        
        // Proteção contra entradas inválidas
        if (!int.TryParse(Console.ReadLine(), out _duracao) || _duracao <= 0)
        {
            _duracao = 30; // Valor padrão de segurança
        }

        Console.Clear();
        Console.WriteLine("Prepare-se...");
        ExibirAnimacaoSpinner(4);
        Console.WriteLine();
    }

    // Exibe as mensagens padronizadas de encerramento
    public void ExibirMensagemFinal()
    {
        Console.WriteLine();
        Console.WriteLine("Muito bem!! Você fez um ótimo trabalho.");
        ExibirAnimacaoSpinner(3);
        Console.WriteLine($"Você concluiu mais uma sessão de {_nome} por {_duracao} segundos.");
        ExibirAnimacaoSpinner(4);
    }

    // Animação de Spinner (Haste Giratória) usando caracteres de texto
    public void ExibirAnimacaoSpinner(int segundos)
    {
        List<string> framesAnimacao = new List<string> { "|", "/", "-", "\\" };
        DateTime tempoFinal = DateTime.Now.AddSeconds(segundos);
        int i = 0;

        while (DateTime.Now < tempoFinal)
        {
            string frame = framesAnimacao[i];
            Console.Write(frame);
            Thread.Sleep(250);
            Console.Write("\b \b"); // Apaga o caractere anterior no console

            i++;
            if (i >= framesAnimacao.Count)
            {
                i = 0;
            }
        }
    }

    // Animação de Contagem Regressiva Visual numérica
    public void ExibirContagemRegressiva(int segundos)
    {
        for (int i = segundos; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // Apaga o número anterior
        }
    }
}