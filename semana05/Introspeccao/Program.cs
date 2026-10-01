/*
   BYU CSE 210 — PROGRAMA DE INTROSPECÇÃO (MINDFULNESS PROGRAM)
   Aluno: Jean Carlos Jeronimo do Amaral Leal
  
  DEMONSTRAÇÃO DE CRIATIVIDADE (GOING BEYOND):
  Este programa excede os requisitos básicos das seguintes formas:
  1. Sistema contra Repetição: Na Atividade de Reflexão, o programa remove temporariamente 
     as perguntas já exibidas de uma lista clonada. Isso assegura que o usuário nunca receba a mesma 
     pergunta na mesma rodada até que todas tenham sido esgotadas.
  2. Proteção contra Entradas Inválidas: O menu principal e o leitor de tempo usam validação robusta 
     com TryParse para impedir falhas de execução ou travamentos caso strings sejam inseridas onde números são esperados.
*/

using System;

class Program
{
    static void Main(string[] args)
    {
        string opcaoMenu = "";

        while (opcaoMenu != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Principal — Programa de Introspecção");
            Console.WriteLine("1. Iniciar Atividade de Respiração");
            Console.WriteLine("2. Iniciar Atividade de Reflexão");
            Console.WriteLine("3. Iniciar Atividade de Listagem");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção (1-4): ");

            opcaoMenu = Console.ReadLine();

            if (opcaoMenu == "1")
            {
                AtividadeRespiracao atividade1 = new AtividadeRespiracao();
                atividade1.Executar();
            }
            else if (opcaoMenu == "2")
            {
                AtividadeReflexao atividade2 = new AtividadeReflexao();
                atividade2.Executar();
            }
            else if (opcaoMenu == "3")
            {
                AtividadeListagem atividade3 = new AtividadeListagem();
                atividade3.Executar();
            }
            else if (opcaoMenu == "4")
            {
                Console.WriteLine("\nObrigado por usar o aplicativo. Lembre-se de reservar um tempo para você todos os dias. Até logo!");
            }
            else
            {
                Console.WriteLine("\nOpção Inválida. Escolha um número entre 1 e 4.");
                Thread.Sleep(2000);
            }
        }
    }
}