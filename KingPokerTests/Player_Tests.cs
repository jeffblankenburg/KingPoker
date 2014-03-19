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
        public void Player_Remove2735CreditsShouldMakeCreditsEqualTo7265()
        {
            Player p = new Player();
            p.RemoveCredits(2735);
            Assert.AreEqual(7265, p.GetCredits());
        }

        [TestMethod]
        public void Player_Add4298CreditsShouldMakeCreditsEqualTo14298()
        {
            Player p = new Player();
            p.AddCredits(4298);
            Assert.AreEqual(14298, p.GetCredits());
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
        public void Player_IncreaseUnitsWageredThreeTimesShouldBeFourUnitsWageredAndRollTriggerShouldBeFalse()
        {
            Player p = new Player();
            bool RollTrigger = p.IncreaseUnitsWagered();
            RollTrigger = p.IncreaseUnitsWagered();
            RollTrigger = p.IncreaseUnitsWagered();
            Assert.AreEqual(false, RollTrigger);
            Assert.AreEqual(4, p.GetUnitsWagered());
        }

        [TestMethod]
        public void Player_IncreaseUnitsWageredFourTimesShouldBeFiveUnitsWageredAndRollTriggerShouldBeTrue()
        {
            Player p = new Player();
            bool RollTrigger = p.IncreaseUnitsWagered();
            RollTrigger = p.IncreaseUnitsWagered();
            RollTrigger = p.IncreaseUnitsWagered();
            RollTrigger = p.IncreaseUnitsWagered();
            Assert.AreEqual(true, RollTrigger);
            Assert.AreEqual(5, p.GetUnitsWagered());
        }
    }
}
