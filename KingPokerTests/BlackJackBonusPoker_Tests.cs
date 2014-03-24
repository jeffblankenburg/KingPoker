using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class BlackJackBonusPoker_Tests
    {
        PokerGame pg;

        public void GameSetup(bool ShouldDeal = true)
        {
            pg = new PokerGame(GameType.BlackJackBonusPoker);
            if (ShouldDeal) pg.Deal();
        }

        [TestMethod]
        public void BlackJackBonusPoker_DeckCount()
        {
            GameSetup(false);
            Assert.AreEqual(52, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void BlackJackBonusPoker_RoyalFlush()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 13, Name = "King" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 10, Name = "Ten" });
            Assert.AreEqual(HandOutcome.RoyalFlush, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourAcesWithBlackJack()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 11, Name = "J" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            Assert.AreEqual(HandOutcome.FourAcesWithBlackJack, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourAcesWithRedJack_ShouldBeJustFourAcesOrJacks()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "J" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            Assert.AreEqual(HandOutcome.FourAcesOrJacks, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_Four2sThru4sWithBlackJack()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 3, Name = "Three" });
            Assert.AreEqual(HandOutcome.Four2sThru4sWithBlackJack, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_Four2sThru4sWithRedJack_ShouldBeJustFourOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 3, Name = "Three" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 3, Name = "Three" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourOfAKindWithBlackJack()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 12, Name = "Queen" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 12, Name = "Queen" });
            Assert.AreEqual(HandOutcome.FourOfAKindWithBlackJack, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourOfAKindWithRedJack_ShouldBeJustFourOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamond" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 7, Name = "Seven" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 7, Name = "Seven" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourAces()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamond" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 14, Name = "Ace" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 14, Name = "Ace" });
            Assert.AreEqual(HandOutcome.FourAcesOrJacks, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_FourJacks()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 2, Name = "Diamond" }, new CardValue { Number = 6, Name = "Six" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 11, Name = "Jack" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 11, Name = "Jack" });
            Assert.AreEqual(HandOutcome.FourAcesOrJacks, pg.CheckHandForOutcome());
        }

        [TestMethod]
        public void BlackJackBonusPoker_StraightFlush()
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
        public void BlackJackBonusPoker_FourOfAKind()
        {
            GameSetup();
            pg.SetCardSuitAndValue(0, new Suit { ID = 1, Name = "Hearts" }, new CardValue { Number = 9, Name = "Nine" });
            pg.SetCardSuitAndValue(1, new Suit { ID = 2, Name = "Diamonds" }, new CardValue { Number = 9, Name = "Nine" });
            pg.SetCardSuitAndValue(2, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 2, Name = "Two" });
            pg.SetCardSuitAndValue(3, new Suit { ID = 4, Name = "Spades" }, new CardValue { Number = 9, Name = "Nine" });
            pg.SetCardSuitAndValue(4, new Suit { ID = 3, Name = "Clubs" }, new CardValue { Number = 9, Name = "Nine" });
            Assert.AreEqual(HandOutcome.FourOfAKind, pg.CheckHandForOutcome());
        }
        
        [TestMethod]
        public void BlackJackBonusPoker_FullHouse()
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
        public void BlackJackBonusPoker_Flush()
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
        public void BlackJackBonusPoker_Straight()
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
        public void BlackJackBonusPoker_ThreeOfAKind()
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
        public void BlackJackBonusPoker_TwoPair()
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
        public void BlackJackBonusPoker_JacksOrBetter()
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
