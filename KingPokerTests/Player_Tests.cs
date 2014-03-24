using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KingPoker;

namespace KingPokerTests
{
    [TestClass]
    public class Player_Tests
    {
        [TestMethod]
        public void Player_NewPlayerHas10000Credits()
        {
            Player p = new Player();
            Assert.AreEqual(10000, p.GetCredits());
        }

        [TestMethod]
        public void Player_MakingBetWith5BetUnitsOf1ShouldReducePlayerCreditTotalBy5()
        {
            Player p = new Player();
            if (p.CanIncreaseUnits(5)) p.IncreaseUnitsWagered(5);
            p.RemoveWageredCredits();
            Assert.AreEqual(9995, p.GetCredits());
        }

        [TestMethod]
        public void Player_MakingBetWith5BetUnitsOf100ShouldReducePlayerCreditTotalBy500()
        {
            Player p = new Player();
            p.IncreaseUnitsWagered(5);
            p.ChangeBetUnit(100);
            p.RemoveWageredCredits();
            Assert.AreEqual(9500, p.GetCredits());
        }

        [TestMethod]
        public void Player_MakingBetWith5BetUnitsOf100WithoutEnoughCreditsShouldPreventABet()
        {
            Player p = new Player();
            p.SetCredits(432);
            p.IncreaseUnitsWagered(5);
            p.ChangeBetUnit(100);
            Assert.AreEqual(0, p.GetCreditsWagered());
        }

        [TestMethod]
        public void Player_IncreaseUnitsWageredTwiceShouldBeThreeUnitsWagered()
        {
            Player p = new Player();
            p.IncreaseUnitsWagered();
            p.IncreaseUnitsWagered();
            Assert.AreEqual(3, p.GetUnitsWagered());
        }

        [TestMethod]
        public void Player_IncreaseUnitsWageredToSixShouldBeOneUnitWagered()
        {
            Player p = new Player();
            p.IncreaseUnitsWagered(5);
            p.IncreaseUnitsWagered();
            Assert.AreEqual(1, p.GetUnitsWagered());
        }

        
    }
}
