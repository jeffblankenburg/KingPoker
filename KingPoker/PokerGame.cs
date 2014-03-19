using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class PokerGame
    {
        Deck Deck;
        Hand Hand = new Hand();
        PayTableFactory paytablefactory = new PayTableFactory();
        List<PayTableItem> PayTables;

        public PokerGame(GameType gametype)
        {
            Deck = new Deck(gametype);
            PayTables = paytablefactory.GetPayTable(gametype);
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

        public void SetCardHoldState(int card, bool state)
        {
            Hand.SetCardHoldState(card, state);
        }

        public void SetCardSuitAndValue(int card, Suit s, CardValue cv)
        {
            Hand.Cards[card].Suit = s;
            Hand.Cards[card].CardValue = cv;
        }

        public HandOutcome CheckHandForOutcome(GameType gametype)
        {
            return Hand.CheckForOutcome(gametype);
        }
    }
}
