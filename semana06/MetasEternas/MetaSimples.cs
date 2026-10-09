using System;

public class MetaSimples : Meta
{
    private bool _isConcluida;

    public MetaSimples(string nome, string descricao, int pontos) : base(nome, descricao, pontos)
    {
        _isConcluida = false;
    }

    // Sobrecarga de construtor para fins de leitura e carregamento de arquivo
    public MetaSimples(string nome, string descricao, int pontos, bool isConcluida) : base(nome, descricao, pontos)
    {
        _isConcluida = isConcluida;
    }

    public override int RegistrarEvento()
    {
        if (!_isConcluida)
        {
            _isConcluida = true;
            return GetPontos();
        }
        Console.WriteLine("Esta meta simples já foi concluída anteriormente!");
        return 0;
    }

    public override bool EstaConcluida()
    {
        return _isConcluida;
    }

    public override string ObterDadosParaSalvar()
    {
        return $"{base.ObterDadosParaSalvar()},{_isConcluida}";
    }
}