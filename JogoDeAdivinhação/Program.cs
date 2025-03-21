using System.Security.Cryptography;

namespace JogoDeAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random geradorDeNumeros = new Random();
            int numSecreto = geradorDeNumeros.Next(1, 51);
            int numTentativas;
            int[] histChutes = new int[10];
            int contChutes = 0;

            //pontuação 1000  -   (numero chutado - numero secreto) / 2      -   valor absoluto se valor for negatico

            while (true)
                {
                Console.WriteLine("Jogo da Adivinhação");

                Console.WriteLine("\nEscolha um nível de dificuldade.\n 1 - Fácil(8 Tentativas) \n 2 - Normal(6 Tentativas) \n 3 - Difícil(4 Tentativas)");
                int escolhaDificuldade = Convert.ToInt32(Console.ReadLine());

                if (escolhaDificuldade == 1)
                    numTentativas = 8;
                else if (escolhaDificuldade == 2)
                    numTentativas = 6;
                else
                    numTentativas = 4;

                for (int i = numTentativas; i > 0; i--)
                {
                    Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
                    int numChute = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine($"\nO número que você digitou é {numChute}.");

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
                        histChutes[contChutes] = numChute;
                        contChutes++;
                        continue;
                    }

                    else if (numChute < numSecreto)
                    {
                        numTentativas--;
                        Console.WriteLine($"\nVocê chutou um número menor, tente novamente. Você possui {numTentativas} tentativas.");
                        Console.ReadLine();
                        Console.Clear();
                        histChutes[contChutes] = numChute;
                        contChutes++;
                        continue;
                    }
                    
                }

                Console.WriteLine("\nSeu número de tentativas chegou a 0, você perdeu.");
                
                    Console.Write("\nDeseja jogar novamente? (S/N)");
                    string continuar = Console.ReadLine().ToUpper();

                    if(continuar != "S")
                        break;
                }
        }
    }
}
