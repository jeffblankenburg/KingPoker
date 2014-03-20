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
            if (Units == 1)
            {
                WageredUnits += 1;
                if (WageredUnits == 5) return true;
                else if (WageredUnits > 5) WageredUnits = 1;
                return false;
            }
            else
            {
                WageredUnits = 5;
                return true;
            }
        }

        public void ChangeBetUnit(int betunit)
        {
            BetUnit = betunit;
        }

        public void AddCredits(int credits)
        {
            Credits += credits;
        }

        public void RemoveCredits(int credits)
        {
            Credits -= credits;
        }

        public int GetCredits()
        {
            return Credits;
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
            if ((WageredUnits * BetUnit) < Credits) return WageredUnits * BetUnit;
            return Credits;
        }
    }
}
