using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Player
    {
        public string Id { get; set; }
        public string Nick { get; set; }
        public int XP { get; set; }
        public bool isWiner { get; set; }
        public bool isLoser { get; set; }
        public bool isReady { get; set; }
        public List<Card> Cards { get; set; }

        public void AddXP()
        {
            for (int i = 0; i < Cards.Count; i++)
                if (Cards.ElementAt(i).Type == CardType.Resources)
                    XP += Cards.ElementAt(i).Points;
        }

    }
}
