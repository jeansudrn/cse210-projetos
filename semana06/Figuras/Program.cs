using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criação da lista para armazenar os diferentes tipos de figuras
        List<Figura> listaDeFiguras = new List<Figura>();

        // Instanciando e adicionando um Quadrado (cor vermelha, lado 4)
        Quadrado figuraQuadrado = new Quadrado("Vermelho", 4.0);
        listaDeFiguras.Add(figuraQuadrado);

        // Instanciando e adicionando um Retângulo (cor azul, largura 5, altura 6)
        Retangulo figuraRetangulo = new Retangulo("Azul", 5.0, 6.0);
        listaDeFiguras.Add(figuraRetangulo);

        // Instanciando e adicionando um Círculo (cor verde, raio 3)
        Circulo figuraCirculo = new Circulo("Verde", 3.0);
        listaDeFiguras.Add(figuraCirculo);

        Console.WriteLine("==================================================");
        Console.WriteLine("          RELATÓRIO DE ÁREAS DAS FIGURAS          ");
        Console.WriteLine("==================================================\n");

        // Loop polimórfico: trata todos os objetos apenas como "Figura"
        foreach (Figura figura in listaDeFiguras)
        {
            string cor = figura.ObterCor();
            double area = WetAreaFormatada(figura.ObterArea());

            // Identifica textualmente o tipo do objeto em tempo de execução para o relatório
            string tipoFigura = figura.GetType().Name;

            Console.WriteLine($"Tipo de Figura: {tipoFigura}");
            Console.WriteLine($"Cor do Papel  : {cor}");
            Console.WriteLine($"Área Calculada : {area:0.00}");
            Console.WriteLine("--------------------------------------------------");
        }
    }

    // Método auxiliar apenas para garantir o retorno numérico correto
    static double WetAreaFormatada(double valorArea)
    {
        return valorArea;
    }
}