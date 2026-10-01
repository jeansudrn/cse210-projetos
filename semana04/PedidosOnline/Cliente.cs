using System;

public class Cliente
{
    private string _nome;
    private Endereco _endereco;

    public Cliente(string nome, Endereco endereco)
    {
        _nome = nome;
        _endereco = endereco;
    }

    public bool MoraNosEua()
    {
        return _endereco.EhNosEua();
    }

    public string GetNome() 
    { 
        return _nome; 
    }

    public Endereco GetEndereco() 
    { 
        return _endereco; 
    }
}
