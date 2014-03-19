using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class Deck
    {
        private List<Card> Cards;

        private List<Suit> Suits = new List<Suit> { new Suit { Name = "Hearts", ID = 1 }, new Suit { Name = "Diamonds", ID = 2 }, new Suit { Name = "Clubs", ID = 3 }, new Suit { Name = "Spades", ID = 4 } };
        private List<CardValue> CardValues = new List<CardValue> { new CardValue { Name = "Two", Number = 2 }, new CardValue { Name = "Three", Number = 3 }, new CardValue { Name = "Four", Number = 4 }, new CardValue { Name = "Five", Number = 5 }, new CardValue { Name = "Six", Number = 6 }, new CardValue { Name = "Seven", Number = 7 }, new CardValue { Name = "Eight", Number = 8 }, new CardValue { Name = "Nine", Number = 9 }, new CardValue { Name = "Ten", Number = 10 }, new CardValue { Name = "Jack", Number = 11 }, new CardValue { Name = "Queen", Number = 12 }, new CardValue { Name = "King", Number = 13 }, new CardValue { Name = "Ace", Number = 14 } };
        
        internal Deck(GameType gametype)
        {
            Cards = new List<Card>();
            string x = String.Empty;
            foreach (Suit s in Suits)
            {
                foreach (CardValue v in CardValues)
                {
                    Cards.Add(new Card(s, v));
                }
            }

            switch (gametype)
            {
                case GameType.JokerPoker:
                    Cards.Add(new Card(new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "JOKER" }));
                    break;
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random r = new Random();
            for (int i = 0; i < Cards.Count; i++)
            {
                int index1 = i;
                int index2 = r.Next(Cards.Count);
                SwapCard(index1, index2);
            }
        }

        internal Card Draw()
        {
            Card card = Cards[0];
            Cards.RemoveAt(0);
            return card;
        }

        private void SwapCard(int index1, int index2)
        {
            Card card = Cards[index1];
            Cards[index1] = Cards[index2];
            Cards[index2] = card;
        }

        internal int CountCardsInDeck()
        {
            return Cards.Count();
        }

        internal Card RevealNextCardInDeck()
        {
            return Cards[0];
        }
    }
}
