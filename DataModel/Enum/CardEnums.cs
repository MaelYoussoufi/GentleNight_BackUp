using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DataModel.Enum
{
    public enum CardType
    {
        Kindle = 0, // Basic card type
        AsheOf = 1, // Cards that can get activated
        Kiln = 2, // Cards that stay in play if (Condition) is fulfilled
    }

    public enum CardOrigin
    {
        StartingDeck = 0, // Cards players starts with
        Boon = 1, // Cards players can acquire willingly
        Curse = 2 // Cards forced upon a player
    }
}
