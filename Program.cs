using System;
using System.Collections.Generic;
using JogoDaForca.Classes;

namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lista de Palavras usadas no jogo
            List<Palavra> ListadePalavras = new List<Palavra>() {
                new Palavra("pao", "Comida"),
                new Palavra("Alface", "Verdura"),
                new Palavra("Cadeira", "Objeto"),
                new Palavra("Girafa", "Animal")
            };

            //Instanciando o jogo e setando a palavra escolhida randomicamente
            Jogo jogo = new Jogo
            {
                PalavraEscolhida = RandPalavra(ListadePalavras)
            };

            bool ganhou = false;

            while (jogo.Erros.Count < 5 && ganhou == false)
            {
                Console.WriteLine("   ========================== JOGO DA VELHA ========================== \n\n");

                foreach (char c in jogo.PalavraEscolhida.LPalavra())
                {
                    if (jogo.Acertos.Contains(c))
                    {
                        Console.Write(c);
                    }
                    else
                    {
                        Console.Write(" _ ");
                    }
                }

                Console.WriteLine("\n\nDICA:  " + jogo.PalavraEscolhida.dica);

                Console.WriteLine("  ============================ ALFABETO ============================\n");

                Console.WriteLine("         A B C D E F G H I J K L M N O P Q R S T U V W X Y Z\n");

                Console.WriteLine("   ============================ TENTATIVAS ============================\n");

                Console.WriteLine(jogo.Tentativas.ToArray());
                Console.WriteLine("\n\nVOCÊ ERROU: " + jogo.Erros.Count + " VEZES!\n");

                Console.WriteLine("\n\n  Digite uma letra: ");
                char l = char.Parse(Console.ReadLine());
                jogo.EscolherLetra(l);

                // verifica se o usuario acertou todas as letras da palavra e limpa a tela
                ganhou = jogo.Acertos.Count == jogo.PalavraEscolhida.LPalavra().Count;
                Console.Clear();
            }

            if (ganhou == true)
            {
                Console.Clear();
                Console.WriteLine("\n\n\n                          VOCÊ GANHOU !!\n\n\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n\n                           VOCÊ PERDEU !!\n\n\n");
            }
        }

        static public Palavra RandPalavra(List<Palavra> list)
        {
            Random rdn = new Random();
            int rand = rdn.Next(0, list.Count);
            Palavra palavra = list.Find(p => list.IndexOf(p) == rand);

            return palavra;
        }

    }
}
