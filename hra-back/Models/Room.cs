using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Room
    {
        public string Id { get; set; }
        public LinkedList<Player> players { get; set; }
        public Card Attack { get; set; }
        public Card Defend { get; set; }
        public List<Card> roomDeck { get; set; }
        public Counter counter { get; set; }
        public Player current { get; set; }
        public Player next { get; set; }

        public void Play()
        {
            // current = players.First;
            /*while (true)
            {
              //  Thread.Sleep(3000);
                if (current.Next != null)
                    current = current.Next;
                else
                    current = current.List.First;
            }*/
            while (true)
                for(int i = 0; i < players.Count; i++)
            {
                    Thread.Sleep(3000);
                    current = players.ElementAt(i);
                    next = players.ElementAt(i+1>=players.Count ? 0 : i+1);
                }
        }
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

        public Player GetPlayer(string id)
        {
            for (LinkedListNode<Player> node = players.First; node != null; node = node.Next)
            {
                if (node.Value.Id == id)
                {
                    return node.Value;
                }
            }
            return null;
        }
        public void AddCards()
        {
            if(roomDeck.Count>0)
             for (LinkedListNode<Player> node = players.First; node != null; node = node.Next)
            {
                
                    System.Diagnostics.Debug.WriteLine(roomDeck.Count + " ca");
                    node.Value.Cards = roomDeck.Skip(0).Take(4).ToList();
                    roomDeck.RemoveRange(0, 4);
                    System.Diagnostics.Debug.WriteLine(roomDeck.Count + " ac");
                   
                
            }
       
        }

       

    }
}
