using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class JokerPoker_Tests
    {
        [TestMethod]
        public void JokerPoker_DeckCount()
        {
            PokerGame pg = new PokerGame(GameType.JokerPoker);
            Assert.AreEqual(53, pg.CountCardsInDeck());
        }
    }
}
