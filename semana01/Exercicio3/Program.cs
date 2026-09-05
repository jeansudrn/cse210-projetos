using System;

class Program
{
    static void Main(string[] args)
   {
        
        Random geradorRandomico = new Random();
        int numeroMagico = geradorRandomico.Next(1, 101);

        int palpite = -1;

        
        while (palpite != numeroMagico)
        {
            Console.Write("Qual o seu palpite? ");
            palpite = int.Parse(Console.ReadLine());

            if (numeroMagico > palpite)
            {
                Console.WriteLine("Maior");
            }
            else if (numeroMagico < palpite)
            {
                Console.WriteLine("Menor");
            }
            else
            {
                Console.WriteLine("Você adivinhou!");
            }
        } 
   }       
}