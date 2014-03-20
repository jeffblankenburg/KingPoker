using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingPoker
{
    public enum HandOutcome
    {
        RoyalFlushNoDeuces,
        FourDeuces,
        RoyalFlushWithDeuces,
        FiveOfAKind,
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        Four2s3s4s,
        Four5sThruKings,
        TwoPair,
        JacksOrBetter,
        FourJsQsKs,
        Four2sThru10s,
        FourAces,
        FourDeucesPlusAce,
        FiveAces,
        Five3s4s5s,
        Five6sThruKs,
        Nothing,
        RoyalFlushNoWild,
        RoyalFlushWithWild,
        KingsOrBetter,
        RoyalFlush,
        Pair,
        Five3sThru5s
    }
}
