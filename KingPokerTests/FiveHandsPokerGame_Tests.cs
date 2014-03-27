using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;
using System.Diagnostics;

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
        public void FiveHandsPokerGame_AfterDealAllFiveDecksShouldBeDifferent()
        {
            FiveHandsPokerGame pg = new FiveHandsPokerGame(GameType.DeucesWild);

            pg.Deal();
            WriteDeckToOutput(pg.PokerGames[0].Deck);
            WriteDeckToOutput(pg.PokerGames[1].Deck);
            WriteDeckToOutput(pg.PokerGames[2].Deck);
            WriteDeckToOutput(pg.PokerGames[3].Deck);
            WriteDeckToOutput(pg.PokerGames[4].Deck);

            //Assert.AreEqual(47, pg.PokerGames[0].CountCardsInDeck());
            //Assert.AreEqual(47, pg.PokerGames[1].CountCardsInDeck());
            //Assert.AreEqual(47, pg.PokerGames[2].CountCardsInDeck());
            //Assert.AreEqual(47, pg.PokerGames[3].CountCardsInDeck());
            //Assert.AreEqual(47, pg.PokerGames[4].CountCardsInDeck());

            Assert.AreEqual(false, pg.PokerGames[0].Deck.Cards[0] == pg.PokerGames[1].Deck.Cards[0]);
            Assert.AreEqual(false, pg.PokerGames[1].Deck.Cards[0] == pg.PokerGames[2].Deck.Cards[0]);
            Assert.AreEqual(false, pg.PokerGames[2].Deck.Cards[0] == pg.PokerGames[3].Deck.Cards[0]);
            Assert.AreEqual(false, pg.PokerGames[3].Deck.Cards[0] == pg.PokerGames[4].Deck.Cards[0]);
            Assert.AreEqual(false, pg.PokerGames[4].Deck.Cards[0] == pg.PokerGames[0].Deck.Cards[0]);
        }

        private void WriteDeckToOutput(Deck d)
        {
            foreach (Card c in d.Cards)
            {
                Debug.Write(c.CardValue.Number.ToString() + c.Suit.Name.Substring(0, 1) + " ");
            }
            Debug.WriteLine("");
        }
    }
}
