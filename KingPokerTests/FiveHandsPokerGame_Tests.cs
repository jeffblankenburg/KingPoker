using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class FiveHandsPokerGame_Tests
    {
        [TestMethod]
        public void FiveHandsPokerGame_CreateTwoGamesAndCopyDeckFromOneToTheOtherThenShuffleBoth_DecksShouldBeDifferentAgain()
        {
            PokerGame pg1 = new PokerGame(GameType.DeucesWild);
            PokerGame pg2 = new PokerGame(GameType.DeucesWild);

            pg2.Deck = new Deck(pg1.Deck);
            pg1.Deck.Shuffle();
            pg2.Deck.Shuffle();

            Assert.AreEqual(false, pg1.Deck == pg2.Deck);
        }

        [TestMethod]
        public void FiveHandsPokerGame_CreateTwoGamesAndCopyHandFromOneToTheOtherThenDraw_HandsShouldBeDifferentAgain()
        {
            FiveHandsPokerGame pg = new FiveHandsPokerGame(GameType.DeucesWild);

            pg.PokerGames[0].Deal();

            Assert.AreEqual(false, pg.PokerGames[0].Deck == pg.PokerGames[1].Deck);
        }
    }
}
