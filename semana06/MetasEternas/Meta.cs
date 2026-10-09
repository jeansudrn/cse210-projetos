using System;

public abstract class Meta
{
    private string _nome;
    private string _descricao;
    private int _pontos;

    public Meta(string nome, string descricao, int pontos)
    {
        _nome = nome;
        _descricao = descricao;
        _pontos = pontos;
    }

    public string GetNome()
    {
        return _nome;
    }

    public string GetDescricao()
    {
        return _descricao;
    }

    public int GetPontos()
    {
        return _pontos;
    }

    // Métodos abstratos e virtuais que sustentam o polimorfismo
    public abstract int RegistrarEvento();
    public abstract bool EstaConcluida();

    public virtual string ObterStringExibicao()
    {
        string status = EstaConcluida() ? "[X]" : "[ ]";
        return $"{status} {_nome} ({_descricao})";
    }

    // Método virtual para exportação de dados estruturados em texto simples
    public virtual string ObterDadosParaSalvar()
    {
        return $"{GetType().Name}:{_nome},{_descricao},{_pontos}";
    }
}