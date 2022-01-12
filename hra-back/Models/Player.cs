using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Player
    {
        int Id { get; set; }
        string Nick { get; set; }
        int XP { get; set; }
        List<Card> Cards { get; set; }

    }
}
