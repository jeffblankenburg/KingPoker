using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class JokerPoker_Tests
    {
        PokerGame pg;
        GameType gt = GameType.JokerPoker;

        public void GameSetup(bool ShouldDeal = true)
        {
            pg = new PokerGame(gt);
            if (ShouldDeal) pg.Deal();
        }
        
        [TestMethod]
        public void JokerPoker_DeckCount()
        {
            GameSetup(false);
            Assert.AreEqual(53, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void JokerPoker_RoyalFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushNoWild, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_FiveOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            Assert.AreEqual(HandOutcome.FiveOfAKind, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_RoyalFlushWithWild()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushWithWild, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_StraightFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 8, Name = "Eight" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_StraightFlush_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 8, Name = "Eight" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_FourOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_FourOfAKind_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_FullHouse()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            Assert.AreEqual(HandOutcome.FullHouse, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_FullHouse_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            Assert.AreEqual(HandOutcome.FullHouse, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_Flush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.Flush, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_Flush_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.Flush, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_Straight()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_Straight_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_ThreeOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_ThreeOfAKind_1Joker()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_TwoPair()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.TwoPair, pg.CheckHandForOutcome(gt));
        }

        [TestMethod]
        public void JokerPoker_KingsOrBetter()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.KingsOrBetter, pg.CheckHandForOutcome(gt));
        }
    }
}
