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

        pedido1.AdicionarProduto(new Produto("Notebook Gamer", "PROD001", 1200.00, 1));
        pedido1.AdicionarProduto(new Produto("Mouse Sem Fio", "PROD002", 45.50, 2));
        pedido1.AdicionarProduto(new Produto("Mousepad Pro", "PROD003", 25.00, 1));

        // =========================================================================
        // PEDIDO 2: Cliente Internacional (Envio mais caro: $35)
        // =========================================================================
        Endereco endereco2 = new Endereco("Av. Paulista, 1000", "São Paulo", "SP", "Brazil");
        Cliente cliente2 = new Cliente("Maria Silva", endereco2);
        Pedido pedido2 = new Pedido(cliente2);

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
