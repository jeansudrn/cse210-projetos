using System;

public class MetaEterna : Meta
{
    public MetaEterna(string nome, string descricao, int pontos) : base(nome, descricao, pontos)
    {
    }

    public override int RegistrarEvento()
    {
        // Metas eternas nunca terminam, sempre concedem a pontuação base fixa
        return GetPontos();
    }

    public override bool EstaConcluida()
    {
        return false;
    }
}