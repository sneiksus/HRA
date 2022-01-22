using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back
{

    public enum CardType { Attack, Resources, Thief, Sabotage};
    public class Card
    {
        public CardType Type { get; set; }
        public int Points { get; set; }

    }
}
