using System;

class Program
{
    static void Main(string[] args)
    {
        Diario meuDiario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        string opcao = "";

        Console.WriteLine("Bem-vindo ao Programa de Diário!");

        while (opcao != "5")
        {
            Console.WriteLine("\nPor favor, selecione uma das seguintes opções:");
            Console.WriteLine("1. Escrever");
            Console.WriteLine("2. Exibir");
            Console.WriteLine("3. Carregar");
            Console.WriteLine("4. Salvar");
            Console.WriteLine("5. Sair");
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
                Console.WriteLine("Até logo!");
            }
            else
            {
                Console.WriteLine("Opção inválida. Escolha um número de 1 a 5.");
            }
        }
    }
}