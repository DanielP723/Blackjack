using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    
    
    
    class Player
    {
        List<string> deck;
        List<string> hand;
        public List<string> Hand { get => hand; set => hand = value; }
        public List<string> Deck { get => deck; set => deck = value; }

        public void AddCard(string carta)
        {
            hand.Add(carta);
        }

        /*public void Init()
        {
            for (int i = 0; i < 3; i++)
            {

                AddCard(Dealer.Deal(List<string>));

            }

        }*/
    }
}
