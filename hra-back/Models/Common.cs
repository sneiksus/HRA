using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Common
    {
        public static List<Room> rooms = new List<Room>() { new Room { Id="GT3",players=new LinkedList<Player>()} };
    }
}
