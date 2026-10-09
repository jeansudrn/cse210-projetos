using System;

public class MetaNegativa : Meta
{
    public MetaNegativa(string nome, string descricao, int pontosPenalidade) 
        : base(nome, descricao, pontosPenalidade)
    {
    }

    public override int RegistrarEvento()
    {
        // Retorna o valor negativo dos pontos para subtrair do score geral do usuário
        return -GetPontos();
    }

    public override bool EstaConcluida()
    {
        return false;
    }

    public override string ObterStringExibicao()
    {
        return $"[-] {GetNome()} ({GetDescricao()}) — Penalidade: -{GetPontos()} pontos por deslize";
    }
}