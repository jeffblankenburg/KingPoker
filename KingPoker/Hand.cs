using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class Hand
    {
        public List<Card> Cards = new List<Card> {new Card(), new Card(), new Card(), new Card(), new Card() };
        //public List<Card> Cards = new List<Card>();
        public List<Card> SortedCards = new List<Card>();
        public List<bool> Held = new List<bool>{false, false, false, false, false};
        public GameType GameType;

        internal Hand(GameType gametype)
        {
            GameType = gametype;
        }

        public Hand(Hand h)
        {
            Cards.Clear();
            foreach(Card c in h.Cards)
            {
                Cards.Add(new Card(c));
            }
        }

        public Hand(List<Card> NewCards, List<bool> NewHeld)
        {
            for (int i = 0; i < 5; i++)
            {
                Cards.Add(NewCards[i]);
                Held.Add(NewHeld[i]);
            }
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
                case GameType.DeucesWild_5X:
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
                case GameType.DeucesAndJokerPoker:
                    if (IsFourDeucesAndJoker()) return HandOutcome.FourDeucesAndJoker;
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlushNoDeuces;
                    if (IsFourDeuces()) return HandOutcome.FourDeuces;
                    if (IsRoyalFlushWithWild()) return HandOutcome.RoyalFlushWithWild;
                    if (IsFiveOfAKind()) return HandOutcome.FiveOfAKind;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    break;
                case GameType.DoubleBonusDeucesWild:
                case GameType.DeucesWildBonusPoker:
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
                case GameType.BonusPokerDeluxe:
                case GameType.AllAmericanPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
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
                case GameType.DoubleBonusPoker:
                case GameType.TripleBonusPokerPlus:
                case GameType.WhiteHotAces:
                case GameType.BonusPoker:
                case GameType.SuperAcesBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFour2sThru4s()) return HandOutcome.Four2sThru4s;
                    if (IsFour5sThruKs()) return HandOutcome.Four5sThruKings;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.RoyalAcesBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFour2sThru4s()) return HandOutcome.Four2sThru4s;
                    if (IsFour5sThruKs()) return HandOutcome.Four5sThruKings;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsPairOfAces()) return HandOutcome.PairOfAces;
                    break;
                case GameType.BlackJackBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsFourAcesWithBlackJack()) return HandOutcome.FourAcesWithBlackJack;
                    if (IsFour2sThru4sWithBlackJack()) return HandOutcome.Four2sThru4sWithBlackJack;
                    if (IsFourOfAKindWithBlackJack()) return HandOutcome.FourOfAKindWithBlackJack;
                    if (IsFourAcesOrJacks()) return HandOutcome.FourAcesOrJacks;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.DoubleDoubleBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAcesWith234()) return HandOutcome.FourAcesWith234;
                    if (IsFour2sThru4sWithA234()) return HandOutcome.Four2sThru4sWithA234;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFour2sThru4s()) return HandOutcome.Four2sThru4s;
                    if (IsFour5sThruKs()) return HandOutcome.Four5sThruKings;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.AcesAndFacesPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFourJsThruKs()) return HandOutcome.FourJsThruKs;
                    if (IsFour2sThru10s()) return HandOutcome.Four2sThru10s;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    if (IsPair()) return HandOutcome.Pair;
                    break;
                case GameType.SuperDoubleDoubleBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAcesWith234()) return HandOutcome.FourAcesWith234;
                    if (IsFourAcesWithJQK()) return HandOutcome.FourAcesWithJQK;
                    if (IsFour2sThru4sWithA234()) return HandOutcome.Four2sThru4sWithA234;
                    if (IsFourJsThruKsWithJQKA()) return HandOutcome.FourJsThruKsWithJQKA;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFour2sThru4s()) return HandOutcome.Four2sThru4s;
                    if (IsFour5sThruKs()) return HandOutcome.Four5sThruKings;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.TripleDoubleBonusPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsFourAcesWith234()) return HandOutcome.FourAcesWith234;
                    if (IsFour2sThru4sWithA234()) return HandOutcome.Four2sThru4sWithA234;
                    if (IsFourAces()) return HandOutcome.FourAces;
                    if (IsFour2sThru4s()) return HandOutcome.Four2sThru4s;
                    if (IsFour5sThruKs()) return HandOutcome.Four5sThruKings;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.AcesAndEightsPoker:
                    if (IsRoyalFlush()) return HandOutcome.RoyalFlush;
                    if (IsStraightFlush()) return HandOutcome.StraightFlush;
                    if (IsFourAcesOrEights()) return HandOutcome.FourAcesOr8s;
                    if (IsFourSevens()) return HandOutcome.Four7s;
                    if (IsFourOfAKind()) return HandOutcome.FourOfAKind;
                    if (IsFullHouse()) return HandOutcome.FullHouse;
                    if (IsFlush()) return HandOutcome.Flush;
                    if (IsStraight()) return HandOutcome.Straight;
                    if (IsThreeOfAKind()) return HandOutcome.ThreeOfAKind;
                    if (IsTwoPair()) return HandOutcome.TwoPair;
                    if (IsJacksOrBetter()) return HandOutcome.JacksOrBetter;
                    break;
                case GameType.DoubleJokerPoker:
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
                    break;
            }
            return HandOutcome.Nothing;
        }

        private bool IsFourDeucesAndJoker()
        {
            if ((WhichFourOfAKind() == 2) && (SortedCards[4].CardValue.Number == 1)) return true;
            return false;
        }

        private bool IsFourSevens()
        {
            if (WhichFourOfAKind() == 7) return true;
            return false;
        }

        private bool IsFourAcesOrEights()
        {
            if ((WhichFourOfAKind() == 14) || (WhichFourOfAKind() == 8)) return true;
            return false;
        }

        private bool IsFourJsThruKsWithJQKA()
        {
            if (WhichFourOfAKind() == 11)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[0].CardValue.Number == 13) return true;
                if (SortedCards[0].CardValue.Number == 12) return true;
            }
            if (WhichFourOfAKind() == 12)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[0].CardValue.Number == 13) return true;
                if (SortedCards[4].CardValue.Number == 11) return true;
            }
            if (WhichFourOfAKind() == 13)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[4].CardValue.Number == 12) return true;
                if (SortedCards[4].CardValue.Number == 11) return true;
            }

            return false;
        }

        private bool IsFourAcesWithJQK()
        {
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 11)) return true;
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 12)) return true;
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 13)) return true;
            return false;
        }

        private bool IsFour2sThru10s()
        {
            if ((WhichFourOfAKind() >= 2) && (WhichFourOfAKind() <=10)) return true;
            return false;
        }

        private bool IsFourJsThruKs()
        {
            if (WhichFourOfAKind() == 11) return true;
            if (WhichFourOfAKind() == 12) return true;
            if (WhichFourOfAKind() == 13) return true;
            return false;
        }

        private bool IsFour2sThru4sWithA234()
        {
            if (WhichFourOfAKind() == 2)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[0].CardValue.Number == 4) return true;
                if (SortedCards[0].CardValue.Number == 3) return true;
            }
            if (WhichFourOfAKind() == 3)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[0].CardValue.Number == 4) return true;
                if (SortedCards[4].CardValue.Number == 2) return true;
            }
            if (WhichFourOfAKind() == 4)
            {
                if (SortedCards[0].CardValue.Number == 14) return true;
                if (SortedCards[4].CardValue.Number == 3) return true;
                if (SortedCards[4].CardValue.Number == 2) return true;
            }

            return false;
        }

        private bool IsFourAcesWith234()
        {
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 2)) return true;
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 3)) return true;
            if ((WhichFourOfAKind() == 14) && (SortedCards[4].CardValue.Number == 4)) return true;
            return false;
        }

        private bool IsFourAcesOrJacks()
        {
            if (WhichFourOfAKind() == 14) return true;
            if (WhichFourOfAKind() == 11) return true;
            return false;
        }

        private bool IsFourOfAKindWithBlackJack()
        {
            if (IsFourOfAKind())
            {
                if ((WhichFourOfAKind() >= 12) && ((SortedCards[4].CardValue.Number == 11) && ((SortedCards[4].Suit.ID == 3) || (SortedCards[4].Suit.ID == 4)))) return true;
                if ((WhichFourOfAKind() <= 10) && ((SortedCards[0].CardValue.Number == 11) && ((SortedCards[0].Suit.ID == 3) || (SortedCards[0].Suit.ID == 4)))) return true;
            }
            return false;
        }

        private bool IsFour2sThru4sWithBlackJack()
        {
            if ((IsFour2sThru4s()) && (SortedCards[0].CardValue.Number == 11) && ((SortedCards[0].Suit.ID == 3) || (SortedCards[0].Suit.ID == 4))) return true;
            return false;
        }

        private bool IsFourAcesWithBlackJack()
        {
            if ((IsFourAces()) && (SortedCards[4].CardValue.Number == 11) && ((SortedCards[4].Suit.ID == 3) || (SortedCards[4].Suit.ID == 4))) return true;
            return false;
        }

        private bool IsPairOfAces()
        {
            if (WhichPair() == 14) return true;
            return false;
        }

        private bool IsFour5sThruKs()
        {
            if ((WhichFourOfAKind() >= 5) && (WhichFourOfAKind() <= 13)) return true;
            return false;
        }

        private bool IsFour2sThru4s()
        {
            if ((WhichFourOfAKind() >= 2) && (WhichFourOfAKind() <= 4))return true;
            return false;
        }

        private bool IsFourAces()
        {
            if (WhichFourOfAKind() == 14) return true;
            return false;
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
            if (IsJokerGame())
            {
                if ((CountJokers() == 1) && (WhichHighCard() >=13)) return true;
            }
            return false;
        }

        private bool IsJokerGame()
        {
            if ((GameType == GameType.JokerPoker) || (GameType == GameType.DoubleJokerPoker) || (GameType == GameType.DeucesAndJokerPoker)) return true;
            return false;
        }

        private bool IsNaturalThreeOfAKind()
        {
            if (WhichThreeOfAKind() != 0) return true;
            return false;
        }

        private bool IsThreeOfAKind()
        {
            if (WhichThreeOfAKind() != 0) return true;
            if ((IsDeucesWildGame()) && (IsJokerGame()))
            {
                if ((CountWildCards() == 1) && (WhichPair() >= 3)) return true;
                if (CountWildCards() == 2) return true;
            }
            if (IsDeucesWildGame())
            { 
                if ((CountDeuces() == 1) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountDeuces() == 2) return true;
            }
            if (IsJokerGame())
            {
                if ((CountJokers() == 1) && (WhichPair() >= 2)) return true;
                if (CountJokers() == 2) return true;
            }
            return false;
        }

        public bool IsDeucesWildGame()
        {
            if ((GameType == GameType.DeucesWild) ||
                (GameType == GameType.DoubleBonusDeucesWild) ||
                (GameType == GameType.DeucesWildBonusPoker) ||
                (GameType == GameType.DeucesWild_5X) ||
                (GameType == GameType.DeucesAndJokerPoker)) return true;
            return false;
        }

        private bool IsFourOfAKind()
        {
            if (WhichFourOfAKind() != 0) return true;
            if (IsDeucesWildGame() && IsJokerGame())
            {
                if ((CountWildCards() == 1) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountWildCards() == 2) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountWildCards() == 3) return true;
            }
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountDeuces() == 2) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountDeuces() == 3) return true;
            }
            if (IsJokerGame())
            {
                if ((CountJokers() == 1) && (WhichThreeOfAKind() != 0)) return true;
                if ((CountJokers() == 2) && (WhichPair() != 0) && (WhichPair() != 1)) return true;
            }
            return false;
        }

        private int CountWildCards()
        {
            int totalWildCards = 0;
            if (IsDeucesWildGame()) totalWildCards += (from s in SortedCards where s.CardValue.Number == 2 select s).Count();
            if (IsJokerGame()) totalWildCards += (from s in SortedCards where s.CardValue.Number == 1 select s).Count();
            return totalWildCards;
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
            if (IsDeucesWildGame() && IsJokerGame())
            {
                if ((CountWildCards() == 1) && (WhichFourOfAKind() != 0) && (WhichFourOfAKind() != 2)) return true;
                if ((CountWildCards() == 2) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountWildCards() == 3) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
                if (CountWildCards() == 4) return true;
            }
            if (IsDeucesWildGame())
            {
                if ((CountDeuces() == 1) && (WhichFourOfAKind() != 0) && (WhichFourOfAKind() != 2)) return true;
                if ((CountDeuces() == 2) && (WhichThreeOfAKind() != 0) && (WhichThreeOfAKind() != 2)) return true;
                if ((CountDeuces() == 3) && (WhichPair() != 0) && (WhichPair() != 2)) return true;
            }
            if (IsJokerGame())
            {
                if ((CountJokers() == 1) && (WhichFourOfAKind() != 0)) return true;
                if ((CountJokers() == 2) && (WhichThreeOfAKind() != 0)) return true;
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
            if (IsDeucesWildGame() || IsJokerGame())
            {
                if ((CountWildCards() == 1) && (IsNaturalTwoPair())) return true;
            }            
            return false;
        }

        private bool IsFlush()
        {
            //TRADITIONAL FLUSH WHERE ALL FIVE CARDS HAVE THE SAME SUIT.
            if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID) && (SortedCards[2].Suit.ID == SortedCards[3].Suit.ID) && (SortedCards[3].Suit.ID == SortedCards[4].Suit.ID)) return true;
            if (IsDeucesWildGame() || IsJokerGame())
            {
                if ((CountWildCards() == 1))
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID) && (SortedCards[2].Suit.ID == SortedCards[3].Suit.ID)) return true;
                }
                if (CountWildCards() == 2)
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID) && (SortedCards[1].Suit.ID == SortedCards[2].Suit.ID)) return true;
                }
                if (CountWildCards() == 3)
                {
                    if ((SortedCards[0].Suit.ID == SortedCards[1].Suit.ID)) return true;
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
            if (IsDeucesWildGame() || IsJokerGame())
            {
                if (CountWildCards() == 1)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 2) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1) && (SortedCards[1].CardValue.Number == SortedCards[2].CardValue.Number + 1) && (SortedCards[2].CardValue.Number == SortedCards[3].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4) && (SortedCards[3].CardValue.Number == 3)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 3) && (SortedCards[3].CardValue.Number == 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5) && (SortedCards[2].CardValue.Number == 4) && (SortedCards[3].CardValue.Number == 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4) && (SortedCards[2].CardValue.Number == 3) && (SortedCards[3].CardValue.Number == 2)) return true;
                }
                if (CountWildCards() == 2)
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
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4) && (SortedCards[2].CardValue.Number == 2)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 3) && (SortedCards[2].CardValue.Number == 2)) return true;
                }
                if (CountWildCards() == 3)
                {
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 1)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 2)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 3)) return true;
                    if ((SortedCards[0].CardValue.Number == SortedCards[1].CardValue.Number + 4)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 5)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 4)) return true;
                    if ((SortedCards[0].CardValue.Number == 14) && (SortedCards[1].CardValue.Number == 3)) return true;
                }
                if (CountWildCards() == 4) return true;
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
