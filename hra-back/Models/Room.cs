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


        public bool RemovePlayer(string id)
        {
            for (LinkedListNode<Player> node = players.First; node != null; node = node.Next)
            {
                if(node.Value.Id == id)
                {
                    players.Remove(node);
                    return true;
                }
            }
            return false;
        }

    }
}
