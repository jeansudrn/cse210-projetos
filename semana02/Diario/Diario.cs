using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    private List<Registro> _registros = new List<Registro>();

    // Adiciona uma nova instância de Registro à lista privada
    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

    // Varre a lista delegando a exibição individual para cada objeto Registro
    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário está vazio. Nenhuma entrada encontrada.");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
        }
    }

    // Grava as linhas no arquivo de texto simples usando o delimitador " | "
    public void SalvarEmArquivo(string nomeArquivo)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(nomeArquivo))
            {
                foreach (Registro registro in _registros)
                {
                    escritor.WriteLine(registro.FormatarParaArquivo());
                }
            }
            Console.WriteLine("Diário salvo com sucesso!");
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Erro ao salvar o arquivo: {erro.Message}");
        }
    }

    // Carrega e reconstrói os objetos Registro com base nas linhas tratadas do arquivo
    public void CarregarDeArquivo(string nomeArquivo)
    {
        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine("Arquivo não encontrado. Verifique o nome inserido.");
            return;
        }

        try
        {
            _registros.Clear(); // Limpa dados temporários em memória antes de ler do arquivo
            string[] linhas = File.ReadAllLines(nomeArquivo);

            foreach (string linha in linhas)
            {
                // Cláusula de segurança contra linhas em branco acidentais
                if (string.IsNullOrWhiteSpace(linha)) continue;

                string[] partes = linha.Split(new string[] { " | " }, StringSplitOptions.None);

                if (partes.Length == 3)
                {
                    string data = partes[0];
                    string pergunta = partes[1];
                    string resposta = partes[2];

                    Registro registroCarregado = new Registro(data, pergunta, resposta);
                    _registros.Add(registroCarregado);
                }
            }
            Console.WriteLine("Diário carregado com sucesso!");
        }
        catch (Exception erro)
        {
            Console.WriteLine($"Erro ao carregar o arquivo: {erro.Message}");
        }
    }
}