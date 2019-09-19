using System.Collections.Generic;

namespace JogoDaForca.Classes
{
    class Jogo
    {
        public Palavra PalavraEscolhida { get; set; }
        public List<char> Acertos { get; private set; } = new List<char>();
        public List<char> Erros { get; private set; } = new List<char>();
        public List<char> Tentativas { get; private set; } = new List<char>();

        // verifica se a palavra contém a letra digitada
        public void EscolherLetra(char letra)
        {
            if (!Acertos.Contains(char.ToUpper(letra)))
            {
                if (PalavraEscolhida.LPalavra().Contains(char.ToUpper(letra)))
                {
                    Jogada(true, char.ToUpper(letra));
                }
                else
                {
                    Jogada(false, char.ToUpper(letra));
                }
            }
        }

        //adiciona a letra na lista de acertos ou erros
        public void Jogada(bool tentativa, char c)
        {
            if (tentativa == true)
            {
                List<char> p = PalavraEscolhida.LPalavra();
                while (p.Contains(c))
                {
                    Acertos.Add(c);
                    p.Remove(c);
                }
                Tentativas.Add(c);
            }
            else
            {
                Erros.Add(c);
                Tentativas.Add(c);
            }
        }


    }
}
