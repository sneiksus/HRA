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
        public List<Card> Cards { get; set; }

    }
}
