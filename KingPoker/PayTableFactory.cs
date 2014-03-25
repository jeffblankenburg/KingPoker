using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class PayTableFactory
    {
        public List<PayTableItem> GetPayTable(GameType gametype)
        {
            List<PayTableItem> payTable = new List<PayTableItem>();

            switch (gametype)
            {
                case GameType.DeucesWild:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH NO DEUCES........", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlushNoDeuces });
                    payTable.Add(new PayTableItem { Title = "4 DEUCES.....................................", Coin1 = 200, Coin2 = 400, Coin3 = 600, Coin4 = 800, Coin5 = 1000, Outcome = HandOutcome.FourDeuces });
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH WITH DEUCES....", Coin1 = 20, Coin2 = 40, Coin3 = 60, Coin4 = 80, Coin5 = 100, Outcome = HandOutcome.RoyalFlushWithDeuces });
                    payTable.Add(new PayTableItem { Title = "5 OF A KIND................................", Coin1 = 12, Coin2 = 24, Coin3 = 36, Coin4 = 48, Coin5 = 60, Outcome = HandOutcome.FiveOfAKind });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.ThreeOfAKind });
                    break;
                case GameType.JacksOrBetter:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.BonusPokerDeluxe:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 8, Coin2 = 16, Coin3 = 24, Coin4 = 32, Coin5 = 40, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 6, Coin2 = 12, Coin3 = 18, Coin4 = 24, Coin5 = 30, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.DoubleBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 6, Coin2 = 12, Coin3 = 18, Coin4 = 24, Coin5 = 30, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.TripleBonusPokerPlus:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 100, Coin2 = 200, Coin3 = 300, Coin4 = 400, Coin5 = 500, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 240, Coin2 = 480, Coin3 = 720, Coin4 = 960, Coin5 = 1200, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 120, Coin2 = 240, Coin3 = 360, Coin4 = 480, Coin5 = 600, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 8, Coin2 = 16, Coin3 = 24, Coin4 = 32, Coin5 = 40, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.RoyalAcesBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 100, Coin2 = 200, Coin3 = 300, Coin4 = 400, Coin5 = 500, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "PAIR OF ACES.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.PairOfAces });
                    break;
                case GameType.WhiteHotAces:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 240, Coin2 = 480, Coin3 = 720, Coin4 = 960, Coin5 = 1200, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 120, Coin2 = 240, Coin3 = 360, Coin4 = 480, Coin5 = 600, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 8, Coin2 = 16, Coin3 = 24, Coin4 = 32, Coin5 = 40, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.BonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 40, Coin2 = 80, Coin3 = 160, Coin4 = 240, Coin5 = 320, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 8, Coin2 = 16, Coin3 = 24, Coin4 = 32, Coin5 = 40, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.SuperAcesBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 60, Coin2 = 120, Coin3 = 180, Coin4 = 240, Coin5 = 300, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 7, Coin2 = 14, Coin3 = 21, Coin4 = 28, Coin5 = 35, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.AcesAndFacesPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES..........................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 Js, Qs, Ks...................................", Coin1 = 40, Coin2 = 80, Coin3 = 120, Coin4 = 160, Coin5 = 200, Outcome = HandOutcome.FourJsThruKs });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU 10s.............................", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.Four5sThru10s });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 7, Coin2 = 14, Coin3 = 21, Coin4 = 28, Coin5 = 35, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR....................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER.......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.DoubleBonusDeucesWild:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH NO DEUCES........", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlushNoDeuces });
                    payTable.Add(new PayTableItem { Title = "4 DEUCES PLUS ACE...................", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.FourDeucesPlusAce });
                    payTable.Add(new PayTableItem { Title = "4 DEUCES.....................................", Coin1 = 200, Coin2 = 400, Coin3 = 600, Coin4 = 800, Coin5 = 1000, Outcome = HandOutcome.FourDeuces });
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH WITH DEUCES....", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.RoyalFlushWithDeuces });
                    payTable.Add(new PayTableItem { Title = "5 ACES..........................................", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FiveAces });
                    payTable.Add(new PayTableItem { Title = "5 3s THRU 5s...............................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Five3sThru5s });
                    payTable.Add(new PayTableItem { Title = "5 6s THRU KINGS.......................", Coin1 = 20, Coin2 = 40, Coin3 = 60, Coin4 = 80, Coin5 = 100, Outcome = HandOutcome.Five6sThruKs });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.ThreeOfAKind });
                    break;
                case GameType.DeucesWildBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH NO DEUCES........", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlushNoDeuces });
                    payTable.Add(new PayTableItem { Title = "4 DEUCES PLUS ACE...................", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.FourDeucesPlusAce });
                    payTable.Add(new PayTableItem { Title = "4 DEUCES.....................................", Coin1 = 200, Coin2 = 400, Coin3 = 600, Coin4 = 800, Coin5 = 1000, Outcome = HandOutcome.FourDeuces });
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH WITH DEUCES....", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.RoyalFlushWithDeuces });
                    payTable.Add(new PayTableItem { Title = "5 ACES.........................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.FiveAces });
                    payTable.Add(new PayTableItem { Title = "5 3s THRU 5s...............................", Coin1 = 40, Coin2 = 80, Coin3 = 120, Coin4 = 160, Coin5 = 200, Outcome = HandOutcome.Five3sThru5s });
                    payTable.Add(new PayTableItem { Title = "5 6s THRU KINGS.......................", Coin1 = 20, Coin2 = 40, Coin3 = 60, Coin4 = 80, Coin5 = 100, Outcome = HandOutcome.Five6sThruKs });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 13, Coin2 = 26, Coin3 = 39, Coin4 = 52, Coin5 = 65, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.ThreeOfAKind });
                    break;
                case GameType.JokerPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH NO WILD............", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 4000, Outcome = HandOutcome.RoyalFlushNoWild });
                    payTable.Add(new PayTableItem { Title = "5 OF A KIND................................", Coin1 = 200, Coin2 = 400, Coin3 = 600, Coin4 = 800, Coin5 = 1000, Outcome = HandOutcome.FiveOfAKind });
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH WITH WILD........", Coin1 = 100, Coin2 = 200, Coin3 = 300, Coin4 = 400, Coin5 = 500, Outcome = HandOutcome.RoyalFlushWithWild });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 20, Coin2 = 40, Coin3 = 60, Coin4 = 80, Coin5 = 100, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 10, Coin2 = 20, Coin3 = 30, Coin4 = 40, Coin5 = 50, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 6, Coin2 = 12, Coin3 = 18, Coin4 = 24, Coin5 = 30, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 2, Coin2 = 4, Coin3 = 6, Coin4 = 8, Coin5 = 10, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR...................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "KINGS OR BETTER......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.KingsOrBetter });
                    break;
                case GameType.BlackJackBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES WITH BLACK JACK........", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 4000, Outcome = HandOutcome.FourAcesWithBlackJack });
                    payTable.Add(new PayTableItem { Title = "4 2s,3s,4s W/ BLACK JACK........", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.Four2sThru4sWithBlackJack });
                    payTable.Add(new PayTableItem { Title = "4 of a KIND W/ BLACK JACK....", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourOfAKindWithBlackJack });
                    payTable.Add(new PayTableItem { Title = "4 ACES or JACKS.........................", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourAcesOrJacks });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 OF A KIND................................", Coin1 = 25, Coin2 = 50, Coin3 = 75, Coin4 = 100, Coin5 = 125, Outcome = HandOutcome.FourOfAKind });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 7, Coin2 = 14, Coin3 = 21, Coin4 = 28, Coin5 = 35, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR...................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.DoubleDoubleBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES WITH ANY 2,3,4............", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.FourAcesWith234 });
                    payTable.Add(new PayTableItem { Title = "4 2s,3s,4s W/ ACE,2,3,4.............", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.Four2sThru4sWithA234 });
                    payTable.Add(new PayTableItem { Title = "4 ACES.........................................", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR...................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
                case GameType.SuperDoubleDoubleBonusPoker:
                    payTable.Add(new PayTableItem { Title = "ROYAL FLUSH..............................", Coin1 = 250, Coin2 = 500, Coin3 = 750, Coin4 = 1000, Coin5 = 4000, Outcome = HandOutcome.RoyalFlush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT FLUSH.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.StraightFlush });
                    payTable.Add(new PayTableItem { Title = "4 ACES WITH ANY 2,3,4............", Coin1 = 400, Coin2 = 800, Coin3 = 1200, Coin4 = 1600, Coin5 = 2000, Outcome = HandOutcome.FourAcesWith234 });
                    payTable.Add(new PayTableItem { Title = "4 ACES WITH ANY J,Q,K............", Coin1 = 320, Coin2 = 640, Coin3 = 960, Coin4 = 1280, Coin5 = 1600, Outcome = HandOutcome.FourAcesWithJQK });
                    payTable.Add(new PayTableItem { Title = "4 2s,3s,4s W/ ACE,2,3,4.............", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.Four2sThru4sWithA234 });
                    payTable.Add(new PayTableItem { Title = "4 Js,Qs,Ks W/ J,Q,K,ACE.............", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourJsThruKsWithJQKA });
                    payTable.Add(new PayTableItem { Title = "4 ACES.........................................", Coin1 = 160, Coin2 = 320, Coin3 = 480, Coin4 = 640, Coin5 = 800, Outcome = HandOutcome.FourAces });
                    payTable.Add(new PayTableItem { Title = "4 2s, 3s, 4s...................................", Coin1 = 80, Coin2 = 160, Coin3 = 240, Coin4 = 320, Coin5 = 400, Outcome = HandOutcome.Four2sThru4s });
                    payTable.Add(new PayTableItem { Title = "4 5s THRU KINGS.......................", Coin1 = 50, Coin2 = 100, Coin3 = 150, Coin4 = 200, Coin5 = 250, Outcome = HandOutcome.Four5sThruKings });
                    payTable.Add(new PayTableItem { Title = "FULL HOUSE................................", Coin1 = 9, Coin2 = 18, Coin3 = 27, Coin4 = 36, Coin5 = 45, Outcome = HandOutcome.FullHouse });
                    payTable.Add(new PayTableItem { Title = "FLUSH..........................................", Coin1 = 5, Coin2 = 10, Coin3 = 15, Coin4 = 20, Coin5 = 25, Outcome = HandOutcome.Flush });
                    payTable.Add(new PayTableItem { Title = "STRAIGHT....................................", Coin1 = 4, Coin2 = 8, Coin3 = 12, Coin4 = 16, Coin5 = 20, Outcome = HandOutcome.Straight });
                    payTable.Add(new PayTableItem { Title = "3 OF A KIND................................", Coin1 = 3, Coin2 = 6, Coin3 = 9, Coin4 = 12, Coin5 = 15, Outcome = HandOutcome.ThreeOfAKind });
                    payTable.Add(new PayTableItem { Title = "TWO PAIR...................................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.TwoPair });
                    payTable.Add(new PayTableItem { Title = "JACKS OR BETTER......................", Coin1 = 1, Coin2 = 2, Coin3 = 3, Coin4 = 4, Coin5 = 5, Outcome = HandOutcome.JacksOrBetter });
                    break;
            }

            return payTable;
        }
    }
}
