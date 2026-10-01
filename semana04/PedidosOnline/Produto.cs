using System;

public class Produto
{
    private string _nome;
    private string _idProduto;
    private double _precoPorUnidade;
    private int _quantidade;

    public Produto(string nome, string idProduto, double precoPorUnidade, int quantidade)
    {
        _nome = nome;
        _idProduto = idProduto;
        _precoPorUnidade = precoPorUnidade;
        _quantidade = quantidade; // Corrigido aqui de 'quantity' para 'quantidade'
    }

    public double CalcularCustoTotalProduto()
    {
        return _precoPorUnidade * _quantidade;
    }

    public string GetNome() 
    { 
        return _nome; 
    }

    public string GetId() 
    { 
        return _idProduto; 
    }
}
