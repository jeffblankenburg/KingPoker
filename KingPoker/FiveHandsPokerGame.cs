using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class FiveHandsPokerGame
    {
        public List<PokerGame> PokerGames = new List<PokerGame>();
        GameType GameType;

        public FiveHandsPokerGame(GameType gametype)
        {
            PokerGames.Add(new PokerGame(gametype));
            PokerGames.Add(new PokerGame(gametype));
            PokerGames.Add(new PokerGame(gametype));
            PokerGames.Add(new PokerGame(gametype));
            PokerGames.Add(new PokerGame(gametype));
            GameType = gametype;
        }

        public void Deal()
        {
            PokerGames[0].Deal();
            Random r = new Random();
            for (int i = 1; i <= 4;i++)
            {
                PokerGames[i].Deck = new Deck(PokerGames[0].Deck);
                PokerGames[i].Deck.Shuffle(r);
                PokerGames[i].Hand = new Hand(PokerGames[0].Hand);
            }
        }

        public void Draw()
        {
            for (int i = 0; i <= 4; i++)
            {
                PokerGames[i].Hand.Held = PokerGames[0].Hand.Held;
                PokerGames[i].Draw();
            }
        }

        public void SetCardHoldState(int card, bool state)
        {
            for (int i = 0;i<=4;i++)
            {
                PokerGames[i].Hand.SetCardHoldState(card, state);
            }
        }

        public bool IsCardHeld(int card)
        {
            Hand h = PokerGames[0].GetEntireHand();
            return h.IsCardHeld(card);
        }

        public List<PayTableItem> GetPayTable()
        {
            return PokerGames[0].GetPayTable();
        }

        public List<Card> GetEntireHand(int game)
        {
            return PokerGames[game].Hand.Cards;
        }

        public List<bool> GetEntireHoldStateOfHand(int game)
        {
            return PokerGames[game].Hand.Held;
        }

        public int GetCardValue(int game, int card)
        {
            return PokerGames[game].Hand.Cards[card].CardValue.Number;
        }

        public int GetCardSuit(int game, int card)
        {
            return PokerGames[game].Hand.Cards[card].Suit.ID;
        }

        public HandOutcome CheckHandForOutcome(int game)
        {
            return PokerGames[game].Hand.CheckForOutcome();
        }
    }
}
