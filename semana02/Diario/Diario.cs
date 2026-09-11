using System;
using System.Collections.Generic;
using System.IO;

public class Diario
{
    private List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        _registros.Add(novoRegistro);
    }

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

    public void CarregarDeArquivo(string nomeArquivo)
    {
        if (!File.Exists(nomeArquivo))
        {
            Console.WriteLine("Arquivo não encontrado. Verifique o nome inserido.");
            return;
        }

        try
        {
            _registros.Clear();
            string[] linhas = File.ReadAllLines(nomeArquivo);

            foreach (string linha in linhas)
            {
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

    // Método criado para atender o critério 10 (Criatividade/Going Beyond)
    public void BuscarPorPalavraChave(string palavraChave)
    {
        Console.WriteLine($"\n--- Resultados para a busca: '{palavraChave}' ---");
        bool encontrou = false;

        foreach (Registro registro in _registros)
        {
            if (registro.ContemPalavraChave(palavraChave))
            {
                registro.Exibir();
                encontrou = true;
            }
        }

        if (!encontrou)
        {
            Console.WriteLine("Nenhum registro encontrado com essa palavra-chave.");
        }
    }
}