using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPoker
{
    public class PayTableItem
    {
        public string Title { get; set; }
        public HandOutcome Outcome { get; set; }
        public int Coin1 { get; set; }
        public int Coin2 { get; set; }
        public int Coin3 { get; set; }
        public int Coin4 { get; set; }
        public int Coin5 { get; set; }
    }
}
