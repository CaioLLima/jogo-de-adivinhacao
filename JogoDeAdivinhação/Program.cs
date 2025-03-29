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
                int[] histChutes = new int[8];
                int contChutes = 0;
                int pontuacao = 1000;
                int escolhaDificuldade = ApresentarDificuldades();
                int numTentativas = DefinirNumTentativas(escolhaDificuldade);

                ApresentarDificuldades(); 

                for (int i = numTentativas; i > 0; i--) 
                {
                    VerificaDiferenteDeZero(histChutes); 

                    EscreveNumerosUsados(histChutes);

                    ChuteJogador();

                    VerificaSeChutouNumeroUsado(histChutes);

                    numTentativas = VerificaAcertouMaiorMenor(numSecreto, numTentativas, pontuacao, histChutes, ref contChutes);
                }

                VerificaSePerdeu(numTentativas);

                MostraPontuacao(pontuacao);

                if (!VerificaSeQuerNovamente())
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

        static int DefinirNumTentativas(int escolhaDifuculdade)
        {
            int numTentativas;
            if (escolhaDifuculdade == 1)
                numTentativas = 8;
            else if (escolhaDifuculdade == 2)
                numTentativas = 6;
            else
                numTentativas = 4;
            return numTentativas;
        }

        static void VerificaDiferenteDeZero(int[] histChutes)
        {
            if (histChutes[0] != 0)
                        Console.Write($"\nNúmeros chutados:  ");
        }

        static void EscreveNumerosUsados(int[] histChutes)
        {
            for (int j = 0; j < histChutes.Length; j++)
            {
                if (histChutes[j] != 0)
                    Console.Write($"{histChutes[j]}, ");
            }
        }

        static int ChuteJogador()
        {
            Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
            int numChute = Convert.ToInt32(Console.ReadLine());
            return numChute;
        }

        static void VerificaSeChutouNumeroUsado(int[] histChutes)
        {
            int chute = ChuteJogador();
            for (int j = 0; j < histChutes.Length; j++)
            {
                if (histChutes[j] == chute)
                {
                    Console.WriteLine($"\nO número {ChuteJogador()} já foi chutado. Tente novamente.");
                    Console.Write("\nChute um número (1 à 50) para tentar adivinhar: ");
                    chute = Convert.ToInt32(Console.ReadLine());
                }
            }
        }

        static int VerificaAcertouMaiorMenor(int numSecreto, int numTentativas, int pontuacao, int[] histChutes, ref int contChutes)
        {
            int chute = ChuteJogador(); // Armazena o chute para evitar múltiplas chamadas

            if (chute == numSecreto)
            {
                Console.WriteLine("\nParabéns!! Você acertou o número.");
                Console.ReadLine();

            }
            else if (chute > numSecreto)
            {
                numTentativas--;
                Console.WriteLine($"\nVocê chutou um número maior, tente novamente. Você possui {numTentativas} tentativas. Pressione ENTER para prosseguir...");
                Console.ReadLine();
                Console.Clear();
                
                contChutes++;
            }
            else if (chute < numSecreto)
            {
                numTentativas--;
                Console.WriteLine($"\nVocê chutou um número menor, tente novamente. Você possui {numTentativas} tentativas. Pressione ENTER para prosseguir...");
                Console.ReadLine();
                Console.Clear();

                contChutes++;
            }

            int vaPontuacao = (chute - numSecreto) / 2;
            pontuacao = pontuacao - Math.Abs(vaPontuacao);
            histChutes[contChutes] = ChuteJogador();

            return numTentativas;


        }

        static void VerificaSePerdeu(int numTentativas)
        {
            if (numTentativas == 0)
            {
                Console.WriteLine("\nSeu número de tentativas chegou a 0, você perdeu.");
            }

        }

        static void MostraPontuacao(int pontuacao)
        {
            Console.WriteLine($"\nSua pontuação foi: {pontuacao}");
        }

        static bool VerificaSeQuerNovamente()
        {
            Console.Write("\nDeseja jogar novamente? (S/N): ");
            return Console.ReadLine().Trim().ToUpper() == "S";
        }
    }
}
