using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class FiveHandsPokerGame
    {
        internal List<PokerGame> PokerGames = new List<PokerGame>();
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
            PokerGames[1].SetDeck(PokerGames[0].GetDeck());
            PokerGames[2].SetDeck(PokerGames[0].GetDeck());
            PokerGames[3].SetDeck(PokerGames[0].GetDeck());
            PokerGames[4].SetDeck(PokerGames[0].GetDeck());
            PokerGames[1].Hand = PokerGames[0].Hand;
            PokerGames[2].Hand = PokerGames[0].Hand;
            PokerGames[3].Hand = PokerGames[0].Hand;
            PokerGames[4].Hand = PokerGames[0].Hand;

        }

        public void Draw()
        {
            for (int i = 0; i <= 4; i++)
            {
                for (int j = 0; j<= 4;j++)
                {
                    if (!PokerGames[0].Hand.IsCardHeld(j))
                    {
                        PokerGames[i].Hand.Cards[j] = PokerGames[i].Deck.Draw();
                    }
                }
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

        public bool AreDeucesWild()
        {
            switch (GameType)
            {
                case GameType.DeucesWild:
                case GameType.DeucesWildBonusPoker:
                case GameType.DoubleBonusDeucesWild:
                    return true;
            }
            return false;
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
