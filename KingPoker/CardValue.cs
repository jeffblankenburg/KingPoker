using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class CardValue
    {
        public CardValue()
        {

        }

        public CardValue(CardValue cardvalue)
        {
            Name = cardvalue.Name;
            Number = cardvalue.Number;
        }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}
