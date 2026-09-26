using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // =========================================================================
        // PEDIDO 1: Cliente dos EUA (Envio mais barato: $5)
        // =========================================================================
        Endereco endereco1 = new Endereco("123 Main St", "Rexburg", "ID", "USA");
        Cliente cliente1 = new Cliente("John Doe", endereco1);
        Pedido pedido1 = new Pedido(cliente1);

        // Adicionando 3 produtos ao Pedido 1
        pedido1.AdicionarProduto(new Produto("Notebook Gamer", "PROD001", 1200.00, 1));
        pedido1.AdicionarProduto(new Produto("Mouse Sem Fio", "PROD002", 45.50, 2));
        pedido1.AdicionarProduto(new Produto("Mousepad Pro", "PROD003", 25.00, 1));

        // =========================================================================
        // PEDIDO 2: Cliente Internacional (Envio mais caro: $35)
        // =========================================================================
        Endereco endereco2 = new Endereco("Av. Paulista, 1000", "São Paulo", "SP", "Brazil");
        Cliente cliente2 = new Cliente("Maria Silva", endereco2);
        Pedido pedido2 = new Pedido(cliente2);

        // Adicionando 2 produtos ao Pedido 2
        pedido2.AdicionarProduto(new Produto("Teclado Mecânico", "PROD004", 89.90, 1));
        pedido2.AdicionarProduto(new Produto("Monitor UltraWide", "PROD005", 350.00, 2));

        // =========================================================================
        // EXIBIÇÃO DOS RESULTADOS DOS PEDIDOS
        // =========================================================================
        Console.WriteLine("==================================================");
        Console.WriteLine("          SISTEMA DE PEDIDOS ONLINE               ");
        Console.WriteLine("==================================================\n");

        // --- EXIBINDO PEDIDO 1 ---
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("                  PEDIDO #1                       ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(pedido1.ObterEtiquetaDeEnvio());
        Console.WriteLine(pedido1.ObterEtiquetaDeEmbalagem());
        Console.WriteLine($"Preço Total do Pedido: ${pedido1.CalcularCustoTotal():0.00}");
        Console.WriteLine("\n==================================================\n");

        // --- EXIBINDO PEDIDO 2 ---
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("                  PEDIDO #2                       ");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine(pedido2.ObterEtiquetaDeEnvio());
        Console.WriteLine(pedido2.ObterEtiquetaDeEmbalagem());
        Console.WriteLine($"Preço Total do Pedido: ${pedido2.CalcularCustoTotal():0.00}");
        Console.WriteLine("\n==================================================");
    }
}

// ==========================================
// CLASSE PEDIDO
// ==========================================
class Pedido
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

        // Regra de Encapsulamento do envio: $5 se for EUA, $35 se for fora.
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

// ==========================================
// CLASSE PRODUTO
// ==========================================
class Produto
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
        _quantidade = quantidade;
    }

    public double CalcularCustoTotalProduto()
    {
        return _precoPorUnidade * _quantidade;
    }

    public string GetNome() { return _nome; }
    public string GetId() { return _idProduto; }
}

// ==========================================
// CLASSE CLIENTE
// ==========================================
class Cliente
{
    private string _nome;
    private Endereco _endereco; // O endereço é uma classe própria

    public Cliente(string nome, Endereco endereco)
    {
        _nome = nome;
        _endereco = endereco;
    }

    public bool MoraNosEua()
    {
        // Encapsulamento: Delega a responsabilidade da checagem para a classe Endereco
        return _endereco.EhNosEua();
    }

    public string GetNome() { return _nome; }
    public Endereco GetEndereco() { return _endereco; }
}

// ==========================================
// CLASSE ENDEREÇO
// ==========================================
class Endereco
{
    private string _rua;
    private string _cidade;
    private string _estado;
    private string _pais;

    public Endereco(string rua, string cidade, string estado, string pais)
    {
        _rua = rua;
        _cidade = cidade;
        _estado = estado;
        _pais = pais;
    }

    public bool EhNosEua()
    {
        // Compara ignorando maiúsculas/minúsculas para evitar erros de digitação
        return _pais.ToLower() == "usa" || _pais.ToLower() == "united states" || _pais.ToLower() == "estados unidos";
    }

    public string ObterEnderecoFormatado()
    {
        return $"  {_rua}\n  {_cidade}, {_estado}\n  {_pais}";
    }
}