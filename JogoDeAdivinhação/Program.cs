using System.Security.Cryptography;

namespace JogoDeAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random geradorDeNumeros = new Random();
            int numSecreto = geradorDeNumeros.Next(1, 51);
            int numTentativas = 5;

            Console.WriteLine("Jogo da Adivinhação");

            Console.WriteLine("\nEscolha um nível de dificuldade.\n 1 - Fácil(8 Tentativas) \n 2 - Normal(6 Tentativas) \n 3 - Difícil(4 Tentativas)");
            int escolhaDificuldade = Convert.ToInt32(Console.ReadLine());

            if (escolhaDificuldade == 1)
                numTentativas = 10;

            else if (escolhaDificuldade == 2)
                numTentativas = 7;

            else
                numTentativas = 4;

            while (numTentativas > 0)
                {

                    Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
                    int numChute = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"\nO número que você digitou é {numChute}.");
                    //Console.WriteLine($"O número secreto é {numSecreto}");

                    if (numChute == numSecreto)
                    {
                        Console.WriteLine("\nParabéns!! Você acertou o número.");
                        Console.ReadLine();
                        break;

                    }
                    else if (numChute > numSecreto)
                    {
                        numTentativas--;
                        Console.WriteLine($"\nVocê chutou um número maior, tente novamente. Você possui {numTentativas} tentativas.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    else if (numChute < numSecreto)
                    {
                        numTentativas--;
                        Console.WriteLine($"\nVocê chutou um número menor, tente novamente. Você possui {numTentativas} tentativas.");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }


                    /*Console.Write("Deseja continuar? (S/N)");
                    string continuar = Console.ReadLine().ToUpper();

                    if(continuar != "S")
                    {
                        break;
                    }*/
                }
        }
    }
}
