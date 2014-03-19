using KingPoker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPokerTests
{
    [TestClass]
    public class PokerGame_Tests
    {
        [TestMethod]
        public void PokerGame_DeckCounterShouldBe52ForAStandardGame()
        {
            PokerGame pg = new PokerGame(GameType.DeucesWild);
            Assert.AreEqual(52, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void PokerGame_DealingAHandShouldPopulateTheHandAndReduceTheDeckCountByFive()
        {
            PokerGame pg = new PokerGame(GameType.DeucesWild);
            pg.Deal();
            Assert.AreEqual(5, pg.CountCardsInHand());
            Assert.AreEqual(47, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void PokerGame_DrawingFiveNewCardsShouldReduceTheDeckCountTo42()
        {
            PokerGame pg = new PokerGame(GameType.DeucesWild);
            pg.Deal();
            pg.Draw();
            Assert.AreEqual(42, pg.CountCardsInDeck());
        }

        [TestMethod]
        public void PokerGame_WhenDrawIsCalledTheDeckShouldReduceByTheNumberOfCardsThatAreUnheld()
        {
            PokerGame pg = new PokerGame(GameType.DeucesWild);
            pg.Deal();
            Random r = new Random();
            int random = r.Next(0, 4);
            int expected = 4 - random;
            for (int i = 0; i <= random; i++)
            {
                pg.SetCardHoldState(i, true);
            }
            pg.Draw();
            Assert.AreEqual(47-expected, pg.CountCardsInDeck());
        }
    }
}
