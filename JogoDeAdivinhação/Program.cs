using System.Security.Cryptography;

namespace JogoDeAdivinhação
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Random geradorDeNumeros = new Random();
                int numSecreto = geradorDeNumeros.Next(1, 51);
                int numTentativas;
                int[] histChutes = new int[8];
                int contChutes = 0;
                int pontuacao = 1000;
                int vaPontucao;
                int escolhaDificuldade;

                ApresentarDificuldades();

                

                for (int i = DefinirNumTentativas(); i > 0; i--)
                {
                    if (histChutes[0] != 0)
                        Console.Write($"\nNúmeros chutados:  ");

                    for (int j = 0; j < histChutes.Length; j++)
                    {
                        if (histChutes[j] != 0)
                            Console.Write($"{ histChutes[j]}, ");
                    }

                    Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
                    int numChute = Convert.ToInt32(Console.ReadLine());
                    

                    for (int j = 0; j < histChutes.Length; j++)
                    {   
                           
                        if (histChutes[j] == numChute)
                        {
                            Console.WriteLine($"\nO número {numChute} já foi chutado. Tente novamente.");
                            Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
                            numChute = Convert.ToInt32(Console.ReadLine());
                        }
                    }

                    if (numChute == numSecreto)
                    {
                        Console.WriteLine("\nParabéns!! Você acertou o número.");
                        Console.ReadLine();
                        break;

                    }
                    else if (numChute > numSecreto)
                    {
                        numTentativas--;
                        Console.WriteLine($"\nVocê chutou um número maior, tente novamente. Você possui {numTentativas} tentativas. Pressione ENTER para prosseguir...");
                        Console.ReadLine();
                        Console.Clear();
                        vaPontucao = (numChute - numSecreto) / 2;
                        pontuacao = pontuacao - Math.Abs(vaPontucao);
                        histChutes[contChutes] = numChute;
                        contChutes++;
                        continue;
                    }

                    else if (numChute < numSecreto)
                    {
                        numTentativas--;
                        Console.WriteLine($"\nVocê chutou um número menor, tente novamente. Você possui {numTentativas} tentativas. Pressione ENTER para prosseguir...");
                        Console.ReadLine();
                        Console.Clear();
                        vaPontucao = (numChute - numSecreto) / 2;
                        pontuacao = pontuacao - Math.Abs(vaPontucao);
                        histChutes[contChutes] = numChute;
                        contChutes++;
                        continue;
                    }


                }
                if(numTentativas == 0){
                    Console.WriteLine("\nSeu número de tentativas chegou a 0, você perdeu.");
                }
                
                Console.WriteLine($"\nSua pontuação foi: {pontuacao}");

                Console.Write("\nDeseja jogar novamente? (S/N)");
                string continuar = Console.ReadLine().ToUpper();
                Console.Clear();

                if (continuar != "S")
                    break;
            }
        }

        static int ApresentarDificuldades()
        {
            Console.WriteLine("Jogo da Adivinhação");

            Console.WriteLine("\nEscolha um nível de dificuldade.\n 1 - Fácil(8 Tentativas) \n 2 - Normal(6 Tentativas) \n 3 - Difícil(4 Tentativas)");
            int escolhaDificuldade = Convert.ToInt32(Console.ReadLine());


            return escolhaDificuldade;
        }

        static int DefinirNumTentativas()
        {
            int numTentativas;
            if (ApresentarDificuldades() == 1)
                numTentativas = 8;
            else if (ApresentarDificuldades() == 2)
                numTentativas = 6;
            else
                numTentativas = 4;

            return numTentativas;
        }
    }
}
