using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Common
    {
        public static List<Room> rooms = new List<Room>() { new Room { Id="GT3",players=new LinkedList<Player>()} };
        public  static readonly List<Card> cards = new List<Card>() { 
            new Card { Points = 100, Type = CardType.Attack },
            new Card { Points = 25, Type = CardType.Resources },
            new Card { Points = 50, Type = CardType.Thief },
            new Card { Points = 0, Type = CardType.Sabotage },
            new Card { Points = 100, Type = CardType.Attack },
            new Card { Points = 50, Type = CardType.Thief },
            new Card { Points = 50, Type = CardType.Attack },
            new Card { Points = 150, Type = CardType.Attack },
            new Card { Points = 200, Type = CardType.Attack }
        };
    }
}
