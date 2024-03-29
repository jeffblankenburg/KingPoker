﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class Card
    {
        public Suit Suit {get; set;}
        public CardValue CardValue { get; set; }

        public Card()
        {

        }

        public Card(Card c)
        {
            Suit = new Suit(c.Suit);
            CardValue = new CardValue(c.CardValue);
        }
        
        public Card (Suit suit, CardValue cardvalue)
        {
            Suit = suit;
            CardValue = cardvalue;
        }

    }
}
