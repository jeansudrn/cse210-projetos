using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Criando a lista para armazenar os vídeos (variável local em camelCase)
        List<Video> listaDeVideos = new List<Video>();

        // ==========================================
        // VÍDEO 1
        // ==========================================
        Video video1 = new Video("Aprenda C# em 10 Minutos", "DevPro", 600);
        video1.AdicionarComentario(new Comentario("Carlos Silva", "Excelente tutorial! Me ajudou muito."));
        video1.AdicionarComentario(new Comentario("Ana Souza", "Muito bem explicado, direto ao ponto."));
        video1.AdicionarComentario(new Comentario("Bruno Lima", "Gostei da didática. Faz um sobre POO!"));
        listaDeVideos.Add(video1);

        // ==========================================
        // VÍDEO 2
        // ==========================================
        Video video2 = new Video("Princípios de Design de Software", "Código Limpo", 1250);
        video2.AdicionarComentario(new Comentario("Mariana Costa", "Abstração e Encapsulamento mudaram minha forma de programar."));
        video2.AdicionarComentario(new Comentario("Pedro Santos", "O exemplo do carro ajudou a fixar o conceito."));
        video2.AdicionarComentario(new Comentario("Julia Ramos", "Vídeo obrigatório para qualquer iniciante."));
        video2.AdicionarComentario(new Comentario("Lucas Oliveira", "Ficou meio longo, mas o conteúdo é sensacional."));
        listaDeVideos.Add(video2);

        // ==========================================
        // VÍDEO 3
        // ==========================================
        Video video3 = new Video("Dicas de Produtividade no VS Code", "TechDicas", 450);
        video3.AdicionarComentario(new Comentario("Roberto Melo", "Os atalhos de teclado vão me poupar horas."));
        video3.AdicionarComentario(new Comentario("Fernanda Dias", "Não conhecia metade dessas extensões!"));
        video3.AdicionarComentario(new Comentario("Gabriel Cruz", "Simples, rápido e muito útil. Valeu!"));
        listaDeVideos.Add(video3);

        // ==========================================
        // EXIBIÇÃO DOS DADOS (Iteração pela lista)
        // ==========================================
        Console.WriteLine("==================================================");
        Console.WriteLine("        RELATÓRIO DE MONITORAMENTO DO YOUTUBE     ");
        Console.WriteLine("==================================================\n");

        foreach (Video video in listaDeVideos)
        {
            Console.WriteLine($"Título: {video.GetTitulo()}");
            Console.WriteLine($"Autor/Canal: {video.GetAutor()}");
            Console.WriteLine($"Duração: {video.GetDuracao()} segundos");
            Console.WriteLine($"Total de Comentários: {video.ObterQuantidadeDeComentarios()}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Comentários dos Usuários:");

            // Exibe cada comentário associado ao vídeo
            foreach (Comentario comentario in video.ObterComentarios())
            {
                Console.WriteLine($"  * {comentario.GetNomeDoUsuario()}: \"{comentario.GetTexto()}\"");
            }

            Console.WriteLine("\n==================================================\n");
        }
    }
}