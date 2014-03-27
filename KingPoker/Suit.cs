using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public class Suit
    {
        public string Name { get; set; }
        public int ID { get; set; }

        public Suit()
        {

        }
        
        public Suit(Suit suit)
        {
            Name = suit.Name;
            ID = suit.ID;
        }
        
    }
}
