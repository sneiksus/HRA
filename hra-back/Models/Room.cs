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
        private int i = 0;
        public bool gameStarted = false;

       /* public void Play()
        {
            // current = players.First;
            *//*while (true)
            {
              //  Thread.Sleep(3000);
                if (current.Next != null)
                    current = current.Next;
                else
                    current = current.List.First;
            }*//*
            while (true)
                for(int i = 0; i < players.Count; i++)
            {
                    Thread.Sleep(30000);
                    current = players.ElementAt(i);
                    next = players.ElementAt(i+1>=players.Count ? 0 : i+1);
                    counter = new Counter(Id);
                }
        }*/

        public void Turn()
        {
            System.Diagnostics.Debug.WriteLine(i + " turn");
            counter = null;
            current = players.ElementAt(i);
            next = players.ElementAt(i + 1 >= players.Count ? 0 : i + 1);
            counter = new Counter(Id);
            counter.turn = this.Turn;
            if (i >= players.Count - 1)
                i = 0;
            else
                i++;
        }

        public void fight()
        {
            if(Attack!=null&&Defend!=null&&Attack.Type == Defend.Type)
            {
                switch (Attack.Type)
                {
                    case CardType.Attack:
                        int res = Attack.Points - Defend.Points;
                        if(res >0)
                            players.ElementAt(i + 1 >= players.Count ? 0 : i + 1).XP-=res;
                        break;
                }
                Attack = Defend = null;
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
