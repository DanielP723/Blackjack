using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class Dealer
    {
        List<string> deck;
        List<string> hand;
        public List<string> Deck { get => deck; set => deck = value; }
        public List<string> Hand { get => hand; set => hand = value; }

        public void Generate()
        {
            List<string> pinta = new List<string>(){ "♥","♦","♣","♠" };
            List<string> simbolos = new List<string>(){ "A","2","3","4","5","6","7","8","9","10","J","Q","K"};
            List<string> cartas = new List<string>();
            for (int i = 0; i < pinta.Count; i++)
            {
                for (int j = 0; i < simbolos.Count; j++)
                {
                    deck.Add(simbolos[j] + pinta[i]);
                }
            }
    
        }
        public List<string> Randomize(List<string> deck)
        {
            Random mezcla = new Random();
            for (int i = deck.Count; i > 1; i--)
            {
                int j = mezcla.Next(i + 1);
                string value = deck[j];
                deck[j] = deck[i];
                deck[i] = value;
            }
            return deck;

        }
        public string Deal(List<string> deck)
        {
            int i = deck.Count;
            string carta = deck[i];
            deck.Remove(deck[i]);
            return carta ;
        }
        public void AddCard(string carta)
        {
            hand.Add(carta);
        }
        public void Init()
        {
            for (int i = 0; i < 3; i++)
            {

                AddCard(Deal(deck));

            }
            
        }
    }
}
