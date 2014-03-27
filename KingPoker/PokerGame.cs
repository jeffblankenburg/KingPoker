using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class PokerGame
    {
        public Deck Deck;
        internal GameType GameType;
        public Hand Hand;
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
            Hand.Cards.Clear();
            Hand.Held.Clear();
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

        public Hand GetEntireHand()
        {
            return Hand;
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

        public string GetUserFriendlyHandOutcome()
        {
            PayTableItem pti = (from p in PayTables
                               where p.Outcome == CheckHandForOutcome()
                               select p).FirstOrDefault();

            if (pti != null) return pti.Title.Replace(".","");
            return "";
        }

        public string GetPayBasedOnHandOutCome(int WageredUnits)
        {
            PayTableItem pti = (from p in PayTables
                                where p.Outcome == CheckHandForOutcome()
                                select p).FirstOrDefault();
            if (pti != null)
            {
                switch (WageredUnits)
                {
                    case 1:
                        return pti.Coin1.ToString();
                    case 2:
                        return pti.Coin2.ToString();
                    case 3:
                        return pti.Coin3.ToString();
                    case 4:
                        return pti.Coin4.ToString();
                    case 5:
                        return pti.Coin5.ToString();
                }
            }
            return "";
        }

        public List<PayTableItem> GetPayTable()
        {
            return PayTables;
        }

        public bool AreDeucesWild()
        {
            return Hand.IsDeucesWildGame();
        }

        //public Deck GetDeck()
        //{
        //    return Deck;
        //}

        //public void SetDeck(Deck d)
        //{
        //    Deck.Cards.Clear();
        //    for (int i = 0; i < d.CountCardsInDeck(); i++)
        //    {
        //        //Deck.Cards.Add(d.Cards[i]);
        //        //Deck.Cards.Add(new Card(new Suit{ ID = Int32.Parse(d.Cards[i].Suit.ID.ToString()), Name = d.Cards[i].Suit.Name.ToString()}, new CardValue{Number = Int32.Parse(d.Cards[i].CardValue.Number.ToString()), Name=d.Cards[i].CardValue.Name.ToString()}));
        //    }
        //    Deck.Shuffle();
        //}
    }
}
