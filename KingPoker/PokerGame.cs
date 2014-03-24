﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class PokerGame
    {
        Deck Deck;
        GameType GameType;
        Hand Hand;
        PayTableFactory paytablefactory = new PayTableFactory();
        List<PayTableItem> PayTables;

        public PokerGame(GameType gametype)
        {
            GameType = gametype;
            Deck = new Deck(GameType);
            Hand = new Hand(GameType);
            PayTables = paytablefactory.GetPayTable(GameType);
        }

        public void Deal()
        {
            for (int i = 0; i <= 4; i++)
            {
                Hand.AddCard(Deck.Draw());
                Hand.Held.Add(false);
            }

        }

        public int CountCardsInDeck()
        {
            return Deck.CountCardsInDeck();
        }

        public void Draw()
        {
            for (int i = 0; i <= 4; i++)
            {
                if (!Hand.IsCardHeld(i))
                {
                    Hand.Cards[i] = Deck.Draw();
                }
            }
        }

        public Card RevealNextCardInDeck()
        {
            return Deck.RevealNextCardInDeck();
        }

        public int CountCardsInHand()
        {
            return Hand.CountCardsInHand();
        }

        public bool IsCardHeld(int card)
        {
            return Hand.IsCardHeld(card);
        }

        public void SetCardHoldState(int card, bool state)
        {
            Hand.SetCardHoldState(card, state);
        }

        public int GetCardValue(int card)
        {
            return Hand.Cards[card].CardValue.Number;
        }

        public List<bool> GetEntireHoldStateOfHand()
        {
            return Hand.Held;
        }

        public List<Card> GetEntireHand()
        {
            return Hand.Cards;
        }

        public int GetCardSuit(int card)
        {
            return Hand.Cards[card].Suit.ID;
        }

        public void SetCardSuitAndValue(int card, Suit s, CardValue cv)
        {
            Hand.Cards[card].Suit = s;
            Hand.Cards[card].CardValue = cv;
        }

        public HandOutcome CheckHandForOutcome()
        {
            return Hand.CheckForOutcome();
        }

        public List<PayTableItem> GetPayTable()
        {
            return PayTables;
        }

        public bool AreDeucesWild()
        {
            switch(GameType)
            {
                case GameType.DeucesWild:
                case GameType.DeucesWildBonusPoker:
                case GameType.DoubleBonusDeucesWild:
                    return true;
            }
            return false;
        }
    }
}
