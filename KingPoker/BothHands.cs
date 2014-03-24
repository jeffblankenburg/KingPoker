using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class BothHands
    {
        public int Id { get; set; }
        public string ANID { get; set; }
        public Hand OpeningHand { get; set; }
        public Hand ClosingHand { get; set; }
        public HandOutcome Outcome { get; set; }
        public DateTime TimeStamp { get; set; }
        public GameType GameType { get; set; }
        public int CreditCount { get; set; }
        public bool IsOnline { get; set; }
        public bool IsSnapped { get; set; }

        public BothHands()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
