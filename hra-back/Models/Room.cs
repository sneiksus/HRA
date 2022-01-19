using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Room
    {
        public string Id { get; set; }
        public LinkedList<Player> players { get; set; }


    }
}
