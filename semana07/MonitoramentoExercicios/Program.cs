using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criação de uma lista polimórfica única para agrupar todas as atividades
        List<Atividade> listaDeAtividades = new List<Atividade>();

        // Instanciando e adicionando uma Corrida
        Corrida corridaUsuario = new Corrida("03 Nov 2022", 30, 4.8);
        listaDeAtividades.Add(corridaUsuario);

        // Instanciando e adicionando uma sessão de Ciclismo
        Ciclismo ciclismoUsuario = new Ciclismo("04 Nov 2022", 45, 20.0);
        listaDeAtividades.Add(ciclismoUsuario);

        // Instanciando e adicionando uma sessão de Natação (ex: 40 voltas = 2 km)
        Natacao natacaoUsuario = new Natacao("05 Nov 2022", 40, 40);
        listaDeAtividades.Add(natacaoUsuario);

        Console.WriteLine("==========================================================");
        Console.WriteLine("         ACADEMIA LOCAL — MONITORAMENTO DE EXERCÍCIOS     ");
        Console.WriteLine("==========================================================\n");

        // Loop polimórfico: Invoca o comportamento herdado de forma genérica
        foreach (Atividade atividade in listaDeAtividades)
        {
            Console.WriteLine(atividade.ObterResumo());
        }

        Console.WriteLine("\n==========================================================");
    }
}