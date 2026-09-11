/*
   BYU CSE 210 - PROGRAMA DE DIÁRIO
   Aluno: Jean Carlos Jeronimo do Amaral Leal
  
  DEMONSTRAÇÃO DE CRIATIVIDADE:
  Este programa excede os requisitos básicos de duas formas:
  1. Adiciona a Opção 5 no menu principal que permite ao usuário buscar e filtrar registros 
     antigos por palavra-chave em todo o diário (incluindo perguntas e respostas).
  2. Adiciona um sistema de mensagens de despedida motivacionais aleatórias ao encerrar o programa.
*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        string opcao = "";

        Console.WriteLine("Bem-vindo ao Programa de Diário!");

        while (opcao != "6")
        {
            Console.WriteLine("\nPor favor, selecione uma das seguintes opções:");
            Console.WriteLine("1. Escrever");
            Console.WriteLine("2. Exibir");
            Console.WriteLine("3. Carregar");
            Console.WriteLine("4. Salvar");
            Console.WriteLine("5. Buscar por palavra-chave (Extra)");
            Console.WriteLine("6. Sair");
            Console.Write("O que você gostaria de fazer? ");
            
            opcao = Console.ReadLine();

            if (opcao == "1")
            {
                string pergunta = gerador.ObterPerguntaAleatoria();
                Console.WriteLine($"\n{pergunta}");
                Console.Write("> ");
                string resposta = Console.ReadLine();

                string dataAtual = DateTime.Now.ToShortDateString();

                Registro novoRegistro = new Registro(dataAtual, pergunta, resposta);
                meuDiario.AdicionarRegistro(novoRegistro);
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\n--- Entradas do Diário ---");
                meuDiario.ExibirTodos();
            }
            else if (opcao == "3")
            {
                Console.Write("Qual é o nome do arquivo para carregar? ");
                string arquivo = Console.ReadLine();
                meuDiario.CarregarDeArquivo(arquivo);
            }
            else if (opcao == "4")
            {
                Console.Write("Qual é o nome do arquivo para salvar? ");
                string arquivo = Console.ReadLine();
                meuDiario.SalvarEmArquivo(arquivo);
            }
            else if (opcao == "5")
            {
                Console.Write("Digite a palavra-chave que deseja buscar: ");
                string termo = Console.ReadLine();
                meuDiario.BuscarPorPalavraChave(termo);
            }
            else if (opcao == "6")
            {
                // Funcionalidade extra: Mensagem de despedida motivacional aleatória
                List<string> despedidas = new List<string> { "Até logo!", "Continue escrevendo sua história!", "Tenha um ótimo dia!" };
                Random rand = new Random();
                Console.WriteLine($"\n{despedidas[rand.Next(despedidas.Count)]}");
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha um número de 1 a 6.");
            }
        }
    }
}