using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class Complaint_Tests
    {
        [TestMethod]
        public void Complaint_Ticket6()
        {
            PokerGame pg = new PokerGame(GameType.DeucesWild);
            pg.Deal();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 5, Name = "Five" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 3, Name = "Three" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome(GameType.DeucesWild));
        }

        [TestMethod]
        public void Complaint_Ticket5()
        {
            PokerGame pg = new PokerGame(GameType.JokerPoker);
            pg.Deal();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 5, Name = "Joker" }, new CardValue { Number = 1, Name = "Joker" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome(GameType.JokerPoker));
        }

        [TestMethod]
        public void Complaint_Ticket4()
        {
            PokerGame pg = new PokerGame(GameType.DoubleBonusDeucesWild);
            pg.Deal();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 4, Name = "Four" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 2, Name = "Two" });
            Assert.AreEqual(HandOutcome.StraightFlush, pg.CheckHandForOutcome(GameType.DoubleBonusDeucesWild));
        }
    }
}
