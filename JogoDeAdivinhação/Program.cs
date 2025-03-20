using System.Security.Cryptography;

namespace JogoDeAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random geradorDeNumeros = new Random();
            int numSecreto = geradorDeNumeros.Next(1, 21); ;

            Console.WriteLine("Jogo da Adivinhação");

            while (true)
            {
                
                Console.Write("\nChute um número (1 à 20) para tentar adivinhar: ");
                int numChute = Convert.ToInt32(Console.ReadLine());

               

                Console.WriteLine($"O número que você digitou é {numChute}.");
                //Console.WriteLine($"O número secreto é {numSecreto}");

                if(numChute == numSecreto)
                {
                    Console.WriteLine("\nParabéns!! Você acertou o número.");
                    Console.ReadLine();
                    break;
                    
                }
                else if (numChute > numSecreto)
                { 
                    Console.WriteLine("\nVocê chutou um número maior, tente novamente.");
                    continue;
                }

                else if (numChute < numSecreto)
                {
                    Console.WriteLine("\nVocê chutou um número menor, tente novamente.");
                    continue;
                }


                Console.Write("Deseja continuar? (S/N)");
                string continuar = Console.ReadLine().ToUpper();

                if(continuar != "S")
                {
                    break;
                }
            }
        }
    }
}
