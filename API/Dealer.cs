using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API
{
    public class Dealer
    {
        List<Card> deck;
        List<Card> hand;
        public List<Card> Deck { get => deck; set => deck = value; }
        public List<Card> Hand { get => hand; set => hand = value; }

        public void Generate()
        {
            deck = new List<Card> { };
            List<string> pinta = new List<string>(){ "♥","♦","♣","♠" };
            List<string> simbolos = new List<string>(){ "A","2","3","4","5","6","7","8","9","10","J","Q","K"};

            foreach (string pi in pinta)
            {
                foreach (string si in simbolos)
                {
                    Card c = new Card(pi, si);
                    deck.Add(c);
                }
            }
    
        }
        public void Randomize()
        {
            Random rnd = new Random();

            this.deck= this.deck.OrderBy(x => (rnd.Next())).ToList();

        }
        public Card Deal()
        {
            Card c = this.deck.Last();
            this.deck.Remove(c);
            return c;
        }


            
        
    }
}
