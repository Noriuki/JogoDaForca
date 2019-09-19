using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace JogoDaForca.Classes
{
    class Palavra
    {
        public string palavra { get; private set; }
        public string dica { get; private set; }

        public Palavra(string palavra, string dica)
        {
            // Verica se a palvra é composta apenas por letras
            if (Regex.IsMatch(palavra, @"^[a-zA-Z]+$") && Regex.IsMatch(dica, @"^[a-zA-Z\s]+$"))
            {
                this.palavra = palavra.ToUpper();
                this.dica = dica.ToUpper();
            }

        }

        // retorna a palavra em forma de lista<char>
        public List<char> LPalavra()
        {
            List<char> lista = new List<char>();

            foreach (char c in palavra.ToCharArray())
            {
                lista.Add(c);
            }
            return lista;
        }

    }
}
