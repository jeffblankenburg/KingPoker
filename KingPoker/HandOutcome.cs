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
        Four5sThruKings,
        TwoPair,
        JacksOrBetter,
        Four2sThru10s,
        FourAces,
        FourDeucesPlusAce,
        FiveAces,
        Five6sThruKs,
        Nothing,
        RoyalFlushNoWild,
        RoyalFlushWithWild,
        KingsOrBetter,
        RoyalFlush,
        Pair,
        Five3sThru5s,
        PairOfAces,
        Four5sThru10s,
        FourAcesWith234,
        Four2sThru4sWithA234,
        Four2sThru4s,
        FourAcesWithBlackJack,
        Four2sThru4sWithBlackJack,
        FourOfAKindWithBlackJack,
        FourAcesOrJacks,
        FourJsThruKs,
        FourAcesWithJQK,
        FourJsThruKsWithJQKA,
        FourAcesOr8s,
        Four7s,
        FourDeucesAndJoker
    }
}
