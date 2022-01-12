using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Room
    {
        string Id { get; set; }
        LinkedList<Player> players { get; set; }
    }
}
