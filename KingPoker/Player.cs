using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class Player
    {
        private int WageredUnits = 1;
        private int Credits = 10000;
        private int BetUnit = 1;

        public bool CanIncreaseUnits(int Units = 1)
        {
            int tempUnits;

            if (Units != 1) tempUnits = Units;
            else
            {
                tempUnits = WageredUnits + 1;
                if (tempUnits == 6) return true;
            }

            if (tempUnits > 5) return false;
            if (tempUnits > Credits) return false;

            return true;
        }

        public void IncreaseUnitsWagered(int Units = 1)
        {
            if (Units > 1) WageredUnits = Units;
            else
            {
                WageredUnits++;
                if (WageredUnits == 6) WageredUnits = 1;
            }
        }

        public void ChangeBetUnit(int betunit)
        {
            BetUnit = betunit;
        }

        public void AwardCredits(int award)
        {
            Credits += award;
        }

        public void RemoveWageredCredits()
        {
            Credits -= GetCreditsWagered();
        }

        public int GetCredits()
        {
            return Credits;
        }

        public int GetBetUnit()
        {
            return BetUnit;
        }

        public void SetCredits(int credits)
        {
            Credits = credits;
        }

        public int GetUnitsWagered()
        {
            return WageredUnits;
        }

        public int GetCreditsWagered()
        {
            if ((WageredUnits * BetUnit) <= Credits) return (WageredUnits * BetUnit);
            return 0;
        }
    }
}
