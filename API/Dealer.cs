using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    class Dealer
    {
        public Generate()
        {
            List<string> pinta = new List<string>(){ "♥","♦","♣","♠" };
            List<string> simbolos = new List<string>(){ "A","2","3","4","5","6","7","8","9","10","J","Q","K"};
            List<string> cartas = new List<string>();
            for (int i = 0; i < pinta.Count; i++)
            {
                for (int j = 0; i < simbolos.Count; j++)
                {
                    cartas.Add(simbolos[j] + pinta[i]);
                }
            }
            
        }
        public Deal(string deck)
        {
            
        }

    }
}
