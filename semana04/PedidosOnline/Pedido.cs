using System;
using System.Collections.Generic;

public class Pedido
{
    private List<Produto> _produtos;
    private Cliente _cliente;

    public Pedido(Cliente cliente)
    {
        _cliente = cliente;
        _produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    public double CalcularCustoTotal()
    {
        double totalProdutos = 0;
        foreach (Produto produto in _produtos)
        {
            totalProdutos += produto.CalcularCustoTotalProduto();
        }

        double custoEnvio = _cliente.MoraNosEua() ? 5.00 : 35.00;

        return totalProdutos + custoEnvio;
    }

    public string ObterEtiquetaDeEmbalagem()
    {
        string etiqueta = "ETIQUETA DE EMBALAGEM (Itens do Pedido):\n";
        foreach (Produto produto in _produtos)
        {
            etiqueta += $"- {produto.GetNome()} (ID: {produto.GetId()})\n";
        }
        return etiqueta;
    }

    public string ObterEtiquetaDeEnvio()
    {
        string etiqueta = "ETIQUETA DE ENVIO:\n";
        etiqueta += $"Nome do Cliente: {_cliente.GetNome()}\n";
        etiqueta += $"Endereço:\n{_cliente.GetEndereco().ObterEnderecoFormatado()}\n";
        return etiqueta;
    }
}
