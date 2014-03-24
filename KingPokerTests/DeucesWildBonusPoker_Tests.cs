using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class DeucesWildBonusPoker_Tests
    {
        PokerGame pg;
        GameType gt = GameType.DeucesWildBonusPoker;

        public void GameSetup(bool ShouldDeal = true)
        {
            pg = new PokerGame(gt);
            if (ShouldDeal) pg.Deal();
        }

        [TestMethod]
        public void DeucesWildBonusPoker_DeckCount()
        {
            GameSetup(false);
            Assert.AreEqual(52, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_RoyalFlush()
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
        public void DeucesWildBonusPoker_FourDeucesPlusAce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FourDeucesPlusAce, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_FourDeuces()
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
        public void DeucesWildBonusPoker_RoyalFlushWithDeuces_1Deuce()
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
        public void DeucesWildBonusPoker_RoyalFlushWithDeuces_2Deuces()
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
        public void DeucesWildBonusPoker_RoyalFlushWithDeuces_3Deuces()
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
        public void DeucesWildBonusPoker_FiveAces_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveAces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_FiveAces_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveAces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_FiveAces_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.FiveAces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five3sThru5s_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five3sThru5s, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five3sThru5s_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five3sThru5s, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five3sThru5s_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five3sThru5s, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five6sThruKs_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five6sThruKs, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five6sThruKs_2Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five6sThruKs, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_Five6sThruKs_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Five6sThruKs, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_StraightFlush_0Deuces()
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
        public void DeucesWildBonusPoker_StraightFlush_1Deuce()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_StraightFlush_2Deuces()
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
        public void DeucesWildBonusPoker_StraightFlush_3Deuces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void DeucesWildBonusPoker_FourOfAKind_0Deuces()
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
        public void DeucesWildBonusPoker_FourOfAKind_1Deuce()
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
        public void DeucesWildBonusPoker_FourOfAKind_2Deuces()
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
        public void DeucesWildBonusPoker_FourOfAKind_3Deuces()
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
        public void DeucesWildBonusPoker_FullHouse_0Deuces()
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
        public void DeucesWildBonusPoker_FullHouse_1Deuce()
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
        public void DeucesWildBonusPoker_Flush_0Deuces()
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
        public void DeucesWildBonusPoker_Flush_1Deuce()
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
        public void DeucesWildBonusPoker_Flush_2Deuces()
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
        public void DeucesWildBonusPoker_Straight_0Deuces()
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
        public void DeucesWildBonusPoker_Straight_1Deuce()
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
        public void DeucesWildBonusPoker_Straight_2Deuces()
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
        public void DeucesWildBonusPoker_ThreeOfAKind_0Deuces()
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
        public void DeucesWildBonusPoker_ThreeOfAKind_1Deuce()
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
        public void DeucesWildBonusPoker_ThreeOfAKind_2Deuces()
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
