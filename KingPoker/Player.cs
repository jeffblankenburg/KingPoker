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

        public bool IncreaseUnitsWagered(int Units = 1)
        {
            int PreviousUnitsWagered = WageredUnits;

            if (Units == 1)
            {
                WageredUnits += 1;
                if (WageredUnits > 5) WageredUnits = 1;
            }
            else WageredUnits = 5;

            if ((WageredUnits * BetUnit) > Credits)
            {
                WageredUnits = PreviousUnitsWagered;
                return false;
            }
            return true;

            
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
