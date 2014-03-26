using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class TripleDoubleBonusPoker_Tests
    {
        PokerGame pg;

        public void GameSetup(bool ShouldDeal = true)
        {
            pg = new PokerGame(GameType.TripleDoubleBonusPoker);
            if (ShouldDeal) pg.Deal();
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_DeckCount()
        {
            GameSetup(false);
            Assert.AreEqual(52, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_RoyalFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_FourAcesWith234()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            Assert.AreEqual(HandOutcome.FourAcesWith234, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_Four2sThru4sWithA234()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 4, Name = "Four" });
            Assert.AreEqual(HandOutcome.Four2sThru4sWithA234, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_FourAces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            Assert.AreEqual(HandOutcome.FourAces, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_Four2sThru4s()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Four2sThru4s, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_StraightFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_FullHouse()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 13, Name = "King" });
            Assert.AreEqual(HandOutcome.FullHouse, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_Flush()
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
        public void TripleDoubleBonusPoker_Straight()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.Straight, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_ThreeOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.ThreeOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_TwoPair()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.TwoPair, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void TripleDoubleBonusPoker_JacksOrBetter()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.JacksOrBetter, pg.CheckHandForOutcome());
        }
    }
}
