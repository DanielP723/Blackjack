using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    
    
    
    public class Player
    {
        private List<Card> hand;
        public List<Card> Hand { get => hand; set => hand = value; }

        public void AddCardP(Card f)
        {
            this.hand.Add(f);
        }

        public void InitP(Card a, Card b)
        {

            hand = new List<Card> { };
            AddCardP(a);
            AddCardP(b);
        }

    }
}
