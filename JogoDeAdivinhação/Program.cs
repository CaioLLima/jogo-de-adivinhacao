using System;

namespace JogoDeAdivinhacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IniciarJogo();

                if (!VerificaSeQuerNovamente())
                    break;
            }
        }

        static void IniciarJogo()
        {
            Random geradorDeNumeros = new Random();
            int numSecreto = geradorDeNumeros.Next(1, 51);
            int[] histChutes = new int[8];
            int contChutes = 0;
            int pontuacao = 1000;

            int escolhaDificuldade = ApresentarDificuldades();
            int numTentativas = DefinirNumTentativas(escolhaDificuldade);

            while (numTentativas > 0)
            {
                VerificaDiferenteDeZero(histChutes);
                EscreveNumerosUsados(histChutes);

                int chute = ChuteJogador();

                // Verifica se o número já foi chutado
                while (VerificaSeChutouNumeroUsado(histChutes, chute))
                {
                    Console.WriteLine($"\nO número {chute} já foi chutado. Tente novamente.");
                    chute = ChuteJogador();
                }

                histChutes[contChutes] = chute;
                contChutes++;

                numTentativas = VerificaAcertouMaiorMenor(numSecreto, numTentativas, ref pontuacao, chute);

                if (chute == numSecreto)
                    return;
            }

            VerificaSePerdeu(numTentativas);
            MostraPontuacao(pontuacao);
        }

        static int ApresentarDificuldades()
        {
            Console.WriteLine("Jogo da Adivinhação");
            Console.WriteLine("\nEscolha um nível de dificuldade.");
            Console.WriteLine("1 - Fácil (8 Tentativas)");
            Console.WriteLine("2 - Normal (6 Tentativas)");
            Console.WriteLine("3 - Difícil (4 Tentativas)");
            return Convert.ToInt32(Console.ReadLine());
        }

        static int DefinirNumTentativas(int escolhaDificuldade)
        {
            if (escolhaDificuldade == 1) return 8;
            if (escolhaDificuldade == 2) return 6;
            return 4;
        }

        static void VerificaDiferenteDeZero(int[] histChutes)
        {
            if (histChutes[0] != 0)
                Console.Write("\nNúmeros chutados: ");
        }

        static void EscreveNumerosUsados(int[] histChutes)
        {
            foreach (int num in histChutes)
            {
                if (num != 0)
                    Console.Write($"{num}, ");
            }
        }

        static int ChuteJogador()
        {
            Console.Write("\nChute um número (1 à 50): ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static bool VerificaSeChutouNumeroUsado(int[] histChutes, int chute)
        {
            foreach (int num in histChutes)
            {
                if (num == chute)
                    return true;
            }
            return false;
        }

        static int VerificaAcertouMaiorMenor(int numSecreto, int numTentativas, ref int pontuacao, int chute)
        {
            if (chute == numSecreto)
            {
                Console.WriteLine("\nParabéns!! Você acertou o número.");
                Console.ReadLine();
                return numTentativas;
            }
            else if (chute > numSecreto)
            {
                numTentativas--;
                Console.WriteLine($"\nVocê chutou um número maior. Tentativas restantes: {numTentativas}");
            }
            else
            {
                numTentativas--;
                Console.WriteLine($"\nVocê chutou um número menor. Tentativas restantes: {numTentativas}");
            }

            pontuacao -= Math.Abs((chute - numSecreto) / 2);
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();

            return numTentativas;
        }

        static void VerificaSePerdeu(int numTentativas)
        {
            if (numTentativas == 0)
                Console.WriteLine("\nSuas tentativas acabaram! Você perdeu.");
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