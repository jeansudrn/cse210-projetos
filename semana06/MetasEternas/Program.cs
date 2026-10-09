/*
   BYU CSE 210 — PROGRAMA DE METAS ETERNAS (ETERNAL QUEST)
   Aluno: [Seu Nome Aqui]
  
  DEMONSTRAÇÃO DE CRIATIVIDADE (CRITÉRIO 10 - GOING BEYOND):
  Este programa excede os requisitos básicos das seguintes formas:
  1. Sistema de Níveis Dinâmicos (Level-Up): Implementa um cálculo matemático que determina o 
     nível de experiência do usuário baseado na pontuação atual. Cada vez que o usuário pontua, o console 
     recalcula o progresso e mostra o ranking honorário.
  2. Inclusão de Metas Negativas: O programa permite mapear e gerenciar maus hábitos. Quando o usuário 
     registra um deslize em uma meta negativa, o sistema subtrai pontos da pontuação global acumulada, 
     refletindo um modelo realista de gamificação comportamental.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Meta> _listaDeMetas = new List<Meta>();
    private static int _pontuacaoTotal = 0;

    static void Main(string[] args)
    {
        string opcaoMenu = "";

        while (opcaoMenu != "6")
        {
            int nivelAtual = (_pontuacaoTotal / 1000) + 1; // 1 nível a cada 1000 pontos obtidos
            
            Console.WriteLine("\n==================================================");
            Console.WriteLine($" PONTUAÇÃO ATUAL: {_pontuacaoTotal} pontos | NÍVEL DO JOGADOR: Nv. {nivelAtual}");
            Console.WriteLine("==================================================");
            Console.WriteLine("1. Criar Nova Meta");
            Console.WriteLine("2. Listar Estrutura de Metas");
            Console.WriteLine("3. Salvar Progresso");
            Console.WriteLine("4. Carregar Progresso");
            Console.WriteLine("5. Registrar Conclusão / Evento");
            Console.WriteLine("6. Sair");
            Console.Write("O que deseja fazer? (1-6): ");

            opcaoMenu = Console.ReadLine();

            if (opcaoMenu == "1") { CriarNovaMeta(); }
            else if (opcaoMenu == "2") { ListarMetas(); }
            else if (opcaoMenu == "3") { SalvarDados(); }
            else if (opcaoMenu == "4") { CarregarDados(); }
            else if (opcaoMenu == "5") { RealizarRegistroEvento(); }
        }
    }

    private static void CriarNovaMeta()
    {
        Console.WriteLine("\nTipos de Metas Disponíveis:");
        Console.WriteLine("1. Meta Simples (Conclusão Única)");
        Console.WriteLine("2. Meta Eterna (Progresso Repetitivo)");
        Console.WriteLine("3. Meta Lista de Tarefas (Múltiplas etapas com bônus)");
        Console.WriteLine("4. Meta Negativa (Evitar Maus Hábitos - Extra)");
        Console.Write("Qual tipo de meta deseja criar? ");
        string escolha = Console.ReadLine();

        Console.Write("Digite o nome da meta: ");
        string nome = Console.ReadLine();
        Console.Write("Digite a descrição da meta: ");
        string descricao = Console.ReadLine();
        Console.Write("Digite a pontuação associada a esta meta: ");
        int pontos = int.Parse(Console.ReadLine());

        if (escolha == "1")
        {
            _listaDeMetas.Add(new MetaSimples(nome, descricao, pontos));
        }
        else if (escolha == "2")
        {
            _listaDeMetas.Add(new MetaEterna(nome, descricao, pontos));
        }
        else if (escolha == "3")
        {
            Console.Write("Quantas vezes essa meta deve ser realizada para ser concluída? ");
            int metaAlvo = int.Parse(Console.ReadLine());
            Console.Write("Qual o bônus de pontos ao finalizar todas as repetições? ");
            int bonus = int.Parse(Console.ReadLine());
            _listaDeMetas.Add(new MetaListaDeTarefas(nome, descricao, pontos, metaAlvo, bonus));
        }
        else if (escolha == "4")
        {
            _listaDeMetas.Add(new MetaNegativa(nome, descricao, pontos));
        }
    }

    private static void ListarMetas()
    {
        Console.WriteLine("\n--- SUAS METAS CADASTRADAS ---");
        if (_listaDeMetas.Count == 0)
        {
            Console.WriteLine("Nenhuma meta cadastrada até o momento.");
            return;
        }

        for (int i = 0; i < _listaDeMetas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_listaDeMetas[i].ObterStringExibicao()}");
        }
    }

    private static void RealizarRegistroEvento()
    {
        ListarMetas();
        if (_listaDeMetas.Count == 0) return;

        Console.Write("\nQual meta você realizou? Digite o número correspondente: ");
        int indice = int.Parse(Console.ReadLine()) - 1;

        if (indice >= 0 && indice < _listaDeMetas.Count)
        {
            int pontosGanhos = _listaDeMetas[indice].RegistrarEvento();
            _pontuacaoTotal += pontosGanhos;
            
            if (pontosGanhos > 0)
            {
                Console.WriteLine($"\n🎉 Parabéns! Você faturou +{pontosGanhos} pontos!");
            }
            else if (pontosGanhos < 0)
            {
                Console.WriteLine($"\n⚠️ Deslize registrado. Você foi penalizado em {pontosGanhos} pontos.");
            }
        }
    }

    private static void SalvarDados()
    {
        Console.Write("Digite o nome do arquivo para salvar (ex: metas.txt): ");
        string nomeArquivo = Console.ReadLine();

        using (StreamWriter escritor = new StreamWriter(nomeArquivo))
        {
            escritor.WriteLine(_pontuacaoTotal);
            foreach (Meta meta in _listaDeMetas)
            {
                escritor.WriteLine(meta.ObterDadosParaSalvar());
            }
        }
        Console.WriteLine("Progresso salvo com sucesso!");
    }

    private static void CarregarDados()
    {
        Console.Write("Digite o nome do arquivo para carregar: ");
        string nomeArquivo = Console.ReadLine();

        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine("Arquivo não localizado.");
            return;
        }

        _listaDeMetas.Clear();
        string[] linhas = File.ReadAllLines(nomeArquivo);
        _pontuacaoTotal = int.Parse(linhas[0]);

        for (int i = 1; i < linhas.Length; i++)
        {
            string linha = linhas[i];
            if (string.IsNullOrWhiteSpace(linha)) continue;

            string[] partesPrincipais = linha.Split(':');
            string tipoMeta = partesPrincipais[0];
            string[] partesDados = partesPrincipais[1].Split(',');

            string nome = partesDados[0];
            string descricao = partesDados[1];
            int pontos = int.Parse(partesDados[2]);

            if (tipoMeta == "MetaSimples")
            {
                bool concluida = bool.Parse(partesDados[3]);
                _listaDeMetas.Add(new MetaSimples(nome, descricao, pontos, concluida));
            }
            else if (tipoMeta == "MetaEterna")
            {
                _listaDeMetas.Add(new MetaEterna(nome, descricao, pontos));
            }
            else if (tipoMeta == "MetaListaDeTarefas")
            {
                int atual = int.Parse(partesDados[3]);
                int alvo = int.Parse(partesDados[4]);
                int bonus = int.Parse(partesDados[5]);
                _listaDeMetas.Add(new MetaListaDeTarefas(nome, descricao, pontos, atual, alvo, bonus));
            }
            else if (tipoMeta == "MetaNegativa")
            {
                _listaDeMetas.Add(new MetaNegativa(nome, descricao, pontos));
            }
        }
        Console.WriteLine("Progresso restaurado com sucesso!");
    }
}