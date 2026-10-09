using System;

public class MetaListaDeTarefas : Meta
{
    private int _quantidadeVezesConcluida;
    private int _metaAlvoVezes;
    private int _pontosBonus;

    public MetaListaDeTarefas(string nome, string descricao, int pontos, int metaAlvoVezes, int pontosBonus) 
        : base(nome, descricao, pontos)
    {
        _quantidadeVezesConcluida = 0;
        _metaAlvoVezes = metaAlvoVezes;
        _pontosBonus = pontosBonus;
    }

    public MetaListaDeTarefas(string nome, string descricao, int pontos, int quantidadeVezesConcluida, int metaAlvoVezes, int pontosBonus) 
        : base(nome, descricao, pontos)
    {
        _quantidadeVezesConcluida = quantidadeVezesConcluida;
        _metaAlvoVezes = metaAlvoVezes;
        _pontosBonus = pontosBonus;
    }

    public override int RegistrarEvento()
    {
        if (EstaConcluida())
        {
            Console.WriteLine("Esta meta de lista de tarefas já foi totalmente alcançada!");
            return 0;
        }

        _quantidadeVezesConcluida++;

        // Verifica se alcançou o alvo de repetições para aplicar a bonificação
        if (_quantidadeVezesConcluida == _metaAlvoVezes)
        {
            Console.WriteLine($"\n⭐ BÔNUS ALCANÇADO! Você recebeu um bônus extra de +{_pontosBonus} pontos!");
            return GetPontos() + _pontosBonus;
        }

        return GetPontos();
    }

    public override bool EstaConcluida()
    {
        return _quantidadeVezesConcluida >= _metaAlvoVezes;
    }

    public override string ObterStringExibicao()
    {
        string status = EstaConcluida() ? "[X]" : "[ ]";
        return $"{status} {GetNome()} ({GetDescricao()}) — Atualmente Concluída: {_quantidadeVezesConcluida}/{_metaAlvoVezes} vezes";
    }

    public override string ObterDadosParaSalvar()
    {
        return $"{base.ObterDadosParaSalvar()},{_quantidadeVezesConcluida},{_metaAlvoVezes},{_pontosBonus}";
    }
}