using System;

namespace API
{
    public class Card
    {
        string suit;
        int score;
        string symbol;
        string color;

        public string Suit { get => suit; set => suit = value; }
        public int Score { get => score; set => score = value; }
        public string Symbol { get => symbol; set => symbol = value; }
        public string Color { get => color; set => color = value; }

        public Card(string suit, string symbol)
        {
            this.Suit = suit;
            this.Symbol = symbol;
            if (suit == "♥" || suit == "♦")
            {
                Color = "Rojo";
            }
            else
            {
                Color = "Negro";
            }
            if (symbol == "A")
            {
                Score = 1;
            }
            else
            {
                if (symbol == "J" || symbol == "Q" || symbol == "K")
                {
                    Score = 10;
                }
                if (symbol == "2")
                {
                    Score = 2;
                }
                if (symbol == "3")
                {
                    Score = 3;
                }
                if (symbol == "4")
                {
                    Score = 4;
                }
                if (symbol == "5")
                {
                    Score = 5;
                }
                if (symbol == "6")
                {
                    Score = 6;
                }
                if (symbol == "7")
                {
                    Score = 7;
                }
                if (symbol == "8")
                {
                    Score = 8;
                }
                if (symbol == "9")
                {
                    Score = 9;
                }
                if (symbol == "10")
                {
                    Score = 10;
                }
            }
        }
    }
}
