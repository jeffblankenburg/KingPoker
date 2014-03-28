using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class DeucesWild_5X_5X_Tests
    {
        PokerGame pg;
        GameType gt = GameType.DeucesWild_5X;

        public void GameSetup(bool ShouldDeal = true)
        {
            pg = new PokerGame(gt);
            if (ShouldDeal) pg.Deal();
        }

        [TestMethod]
        public void DeucesWild_5X_DeckCount()
        {
            GameSetup(false);
            Assert.AreEqual(52, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void DeucesWild_5X_RoyalFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushNoDeuces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FourDeuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FourDeuces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_RoyalFlushWithDeuces_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushWithDeuces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_RoyalFlushWithDeuces_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushWithDeuces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_RoyalFlushWithDeuces_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlushWithDeuces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FiveOfAKind_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FiveOfAKind_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FiveOfAKind_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_StraightFlush_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 8, Name = "Eight" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_StraightFlush_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_StraightFlush_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_StraightFlush_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FourOfAKind_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FourOfAKind_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FourOfAKind_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FourOfAKind_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FullHouse_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            Assert.AreEqual(HandOutcome.FullHouse, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_FullHouse_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            Assert.AreEqual(HandOutcome.FullHouse, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Flush_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.Flush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Flush_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.Flush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Flush_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.Flush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Straight_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 8, Name = "Eight" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Straight_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 8, Name = "Eight" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_Straight_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 8, Name = "Eight" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_ThreeOfAKind_0Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_ThreeOfAKind_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWild_5X_ThreeOfAKind_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome());
        }
    }
}
