using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class Hand
    {
        public List<Card> Cards = new List<Card>();
        public List<Card> SortedCards = new List<Card>();
        public List<bool> Held = new List<bool>{false, false, false, false, false};
        public GameType GameType;

        internal Hand(GameType gametype)
        {
            GameType = gametype;
        }
        
        internal void Sort()
        {
            SortedCards.Clear();
            var cards = Cards.OrderByDescending(x => x.CardValue.Number);
            foreach (Card c in cards)
            {
                SortedCards.Add(c);
            }
        }

        internal void Hold(int card, bool state)
        {
            Held[card] = state;
        }

        internal void AddCard(Card card)
        {
            Cards.Add(card);
        }

        internal int CountCardsInHand()
        {
            return Cards.Count();
        }

        internal void SetCardHoldState(int card, bool state)
        {
            Held[card] = state;
        }

        internal bool IsCardHeld(int card)
        {
            return Held[card];
        }

        public HandOutcome CheckForOutcome()
        {
            Sort();

            switch (GameType)
            {
                case GameType.DeucesWild:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlushNoDeuces;
                    if (IsFourDeuces()) return HandOutcome.FourDeuces;
                    if (IsRoyalFlushWithWild()) return HandOutcome.RoyalFlushWithDeuces;
                    if (IsFiveOfAKind()) return HandOutcome.FiveOfAKind;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    break;
                case GameType.DoubleBonusDeucesWild:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlushNoDeuces;
                    if (IsFourDeucesPlusAce()) return HandOutcome.FourDeucesPlusAce;
                    if (IsFourDeuces()) return HandOutcome.FourDeuces;
                    if (IsRoyalFlushWithWild()) return HandOutcome.RoyalFlushWithDeuces;
                    if (IsFiveAces()) return HandOutcome.FiveAces;
                    if (IsFiveThreesThruFives()) return HandOutcome.Five3sThru5s;
                    if (IsFiveSixesThruKings()) return HandOutcome.Five6sThruKs;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    break;
                case GameType.JacksOrBetter:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    if (IsPair()) return HandOutcome.Pair;
                    break;
                case GameType.JokerPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlushNoWild;
                    if (IsFiveOfAKind()) return HandOutcome.FiveOfAKind;
                    if (IsRoyalFlushWithWild()) return HandOutcome.RoyalFlushWithWild;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsKingsOrBetter()) return HandOutcome.KingsOrBetter;
                    break;
            }
            return HandOutcome.Nothing;
        }

        private bool IsFiveSixesThruKings()
        {
            if ((CountDeuces() == 1) && (WhichFourOfAKind() >= 6) && (WhichFourOfAKind() <= 13)) return true;
            if ((CountDeuces() == 2) && (WhichThreeOfAKind() >= 6) && (WhichThreeOfAKind() <= 13)) return true;
            if ((CountDeuces() == 3) && (WhichPair() >= 6) && (WhichPair() <= 13)) return true;
            return false;
        }

        private bool IsFiveThreesThruFives()
        {
            if ((CountDeuces() == 1) && (WhichFourOfAKind() >= 3) && (WhichFourOfAKind() <= 5)) return true;
            if ((CountDeuces() == 2) && (WhichThreeOfAKind() >= 3) && (WhichThreeOfAKind() <= 5)) return true;
            if ((CountDeuces() == 3) && (WhichPair() >= 3) && (WhichPair() <= 5)) return true;
            return false;
        }

        private bool IsFiveAces()
        {
            if ((CountDeuces() == 1) && (WhichFourOfAKind() == 14)) return true;
            if ((CountDeuces() == 2) && (WhichThreeOfAKind() == 14)) return true;
            if ((CountDeuces() == 3) && (WhichPair() == 14)) return true;
            return false;
        }

        private bool IsFourDeucesPlusAce()
        {
            if ((IsFourDeuces()) && (WhichHighCard() == 14)) return true;
            return false;
        }

        private bool IsFourDeuces()
        {
            if (WhichFourOfAKind() == 2) return true;
            return false;
        }

        private bool IsKingsOrBetter()
        {
            if (WhichPair() >= 13) return true;
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1) && (WhichHighCard() >=13)) return true;
            }
            return false;
        }

        private bool IsThreeOfAKind()
        {
            if (WhichThreeOfAKind() != 0) return true;
            if (IsDeucesWildGame())
            { 
                if ((CountDeuces() == 1) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountDeuces() == 2) return true;
            }
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1) && (WhichPair() != 0)) return true;
            }
            return false;
        }

        private bool IsDeucesWildGame()
        {
            if ((GameType == GameType.DeucesWild) || (GameType == GameType.DoubleBonusDeucesWild)) return true;
            return false;
        }

        private bool IsFourOfAKind()
        {
            if (WhichFourOfAKind() != 0) return true;
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountDeuces() == 2) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountDeuces() == 3) return true;
            }
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1) && (WhichThreeOfAKind() != 0)) return true;
            }
            return false;
        }

        private int CountDeuces()
        {
            int totalDeuces = (from s in SortedCards where s.CardValue.Number == 2 select s).Count();
            return totalDeuces;
        }

        private int CountJokers()
        {
            int totalJokers = (from s in SortedCards where s.CardValue.Number == 1 select s).Count();
            return totalJokers;
        }

        private bool IsRoyalFlush()
        {
            if (IsStraightFlush() && (SortedCards[4].CardValue.Number == 10)) return true;
            return false;
        }

        private bool IsRoyalFlushWithWild()
        {
            if ((IsStraightFlush()) && (((from x in SortedCards where x.CardValue.Number <= 9 where x.CardValue.Number >= 3 select x).Count()) == 0)) return true;
            return false;
        }

        private bool IsFiveOfAKind()
        {
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1) && (WhichFourOfAKind() != 0) && (WhichFourOfAKind() != 2)) return true;
                if ((CountDeuces() == 2) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountDeuces() == 3) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
            }
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1) && (WhichFourOfAKind() != 0)) return true;
            }
            return false;
        }

        private bool IsStraightFlush()
        {
            if (IsStraight() && IsFlush()) return true;
            return false;
        }

        private bool IsFullHouse()
        {
            //WHEN THE PAIR IS HIGHER THAN THE THREE OF A KIND, LIKE 8-8-5-5-5
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            //WHEN THE THREE OF A KIND IS HIGHER THAN THE PAIR, LIKE K-K-K-7-7
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1) && (IsNaturalTwoPair())) return true;
                if ((CountDeuces() == 2) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountDeuces() == 3) return true;
            }
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1) && (IsNaturalTwoPair())) return true;
            }
            return false;
        }

        private bool IsFlush()
        {
            //TRADITIONAL FLUSH WHERE ALL FIVE CARDS HAVE THE SAME SUIT.
            if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID) && (SortedCards[2].Suit.ID == SortedCards[3].Suit.ID) && (SortedCards[3].Suit.ID == SortedCards[4].Suit.ID)) return true;
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1))
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID) && (SortedCards[2].Suit.ID == SortedCards[3].Suit.ID)) return true;
                }
                if (CountDeuces() == 2)
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID)) return true;
                }
                if (CountDeuces() == 3)
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID)) return true;
                }
            }
            if (GameType == GameType.JokerPoker)
            {
                if ((CountJokers() == 1))
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID) && (SortedCards[2].Suit.ID == SortedCards[3].Suit.ID)) return true;
                }
            }
            return false;
        }

        private bool IsStraight()
        {
            //ANY TRADITIONAL STRAIGHT, LIKE 5-6-7-8-9
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number + 1)) return true;
            //AN ACE LOW STRAIGHT, LIKE A-2-3-4-5
            if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4) && (SortedCards[3].CardValue.Number == 3) && (SortedCards[4].CardValue.Number == 2)) return true;
            if (IsDeucesWildGame())
            {
                if (CountDeuces() == 1)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4) && (SortedCards[3].CardValue.Number == 3)) return true;
                }
                if (CountDeuces() == 2)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 3) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 3)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 3)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4) && (SortedCards[2].CardValue.Number == 3)) return true;
                }
                if (CountDeuces() == 3)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 3)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 4)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 3)) return true;
                }
            }
            if (GameType == GameType.JokerPoker)
            {
                if (CountJokers() == 1)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4) && (SortedCards[3].CardValue.Number == 3)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4) && (SortedCards[2].CardValue.Number == 3) && (SortedCards[3].CardValue.Number == 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 3) && (SortedCards[3].CardValue.Number == 2)) return true;
                }
                if (CountJokers() == 2)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 3) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 3)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[1].CardValue.Number <= 5)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2) && (SortedCards[1].CardValue.Number <= 5)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 3) && (SortedCards[1].CardValue.Number <= 5)) return true;
                }
            }
            return false;
        }

        private bool IsTwoPair()
        {
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number)) return true;
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            if ((SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            return false;
        }

        private bool IsNaturalTwoPair()
        {
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number)) return true;
            if ((SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) && (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number)) return true;
            return false;
        }

        private bool IsJacksOrBetter()
        {
            if (WhichPair() >= 11) return true;
            return false;
        }

        public bool IsPair()
        {
            if (WhichPair() != 0) return true;
            return false;
        }

        private int WhichFourOfAKind()
        {
            if (SortedCards[0].CardValue.Number == SortedCards[3].CardValue.Number) return SortedCards[0].CardValue.Number;
            if (SortedCards[1].CardValue.Number == SortedCards[4].CardValue.Number) return SortedCards[1].CardValue.Number;
            return 0;
        }

        private int WhichThreeOfAKind()
        {
            if (SortedCards[0].CardValue.Number == SortedCards[2].CardValue.Number) return SortedCards[0].CardValue.Number;
            if (SortedCards[1].CardValue.Number == SortedCards[3].CardValue.Number) return SortedCards[1].CardValue.Number;
            if (SortedCards[2].CardValue.Number == SortedCards[4].CardValue.Number) return SortedCards[2].CardValue.Number;
            return 0;
        }

        private int WhichPair()
        {
            if (SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number) return SortedCards[0].CardValue.Number;
            if (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number) return SortedCards[1].CardValue.Number;
            if (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number) return SortedCards[2].CardValue.Number;
            if (SortedCards[3].CardValue.Number == SortedCards[4].CardValue.Number) return SortedCards[3].CardValue.Number;
            return 0;
        }

        private int WhichHighCard()
        {
            return SortedCards[0].CardValue.Number;
        }
    }
}
