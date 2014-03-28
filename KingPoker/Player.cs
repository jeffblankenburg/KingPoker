using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class Player
    {
        public int WageredUnits = 1;
        private int Credits = 10000;
        private int BetUnit = 1;

        public bool CanIncreaseUnits(int Units = 1, int multiplier = 1)
        {
            int tempUnits;

            if (Units != 1) tempUnits = Units;
            else
            {
                tempUnits = WageredUnits + 1;
                if (tempUnits == 6) return true;
            }

            if (tempUnits > 5) return false;
            if (tempUnits*multiplier > Credits) return false;

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

        public void AwardCredits(Hand h)
        {
            PayTableFactory factory = new PayTableFactory();
            List<PayTableItem> PayTableItems = factory.GetPayTable(h.GameType);

            PayTableItem pti = (PayTableItem)((from p in PayTableItems
                               where p.Outcome == h.CheckForOutcome()
                               select p).FirstOrDefault());

            int award = 0;

            if (pti != null)
            {
                switch (WageredUnits)
                {
                    case 1:
                        award = pti.Coin1;
                        break;
                    case 2:
                        award = pti.Coin2;
                        break;
                    case 3:
                        award = pti.Coin3;
                        break;
                    case 4:
                        award = pti.Coin4;
                        break;
                    case 5:
                        award = pti.Coin5;
                        break;
                }
            }
            
            Credits += award;
        }

        public void RemoveWageredCredits(int handcount = 1)
        {
            Credits -= GetCreditsWagered()*handcount;
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

        public void AwardCredits()
        {
            throw new NotImplementedException();
        }
    }
}
