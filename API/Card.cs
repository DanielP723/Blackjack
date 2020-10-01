using System;

namespace API
{
    public class Card
    {
        
        string suit;
        string symbol;
        int score;
        string color;

        public string Suit { get => suit; set => suit = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public int Score { get => score; set => score = value; }
        public string Color { get => color; set => color = value; }

        public Card(string suit, string symbol)
        {
            this.suit = suit;
            this.symbol = symbol;
            if (suit == "♥" || suit == "♦")
            {
                this.color = "Red";
            }
            else
            {
                this.color= "Black";
            }
            int value;
            try {
                value = Convert.ToInt32(symbol);
            }
            catch (FormatException)
            {
                if (symbol == "A")
                {
                    value = 11;
                }
                else                
                {
                    value = 10;
                }
            }
            this.score = value;
        }
    }
}
