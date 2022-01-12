using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back
{

    enum CardType { Attack, Resources, Thief, Sabotage};
    public class Card
    {
        CardType Type { get; set; }
        int Points { get; set; }

    }
}
