using hra_back.Hubs;
using Microsoft.AspNetCore.SignalR;
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
            if(current!=null)
                current.AddXP();
            System.Diagnostics.Debug.WriteLine(i + " turn");
            if (Attack != null && Defend == null)
                noDefenseFight();
            counter = null;
            current = players.ElementAt(i);
            next = players.ElementAt(i + 1 >= players.Count ? 0 : i + 1);
            if (current.Cards.Any(x => x.Type != CardType.Resources))
            {
                counter = new Counter(Id);
                counter.turn = this.Turn;
            }
            else
                CheckPlayerStatus();
            if (i >= players.Count - 1)
                i = 0;
            else
                i++;
        }
        public async void  CheckPlayerStatus()
        {
            for(int i = 0; i < players.Count; i++)
            {
               
                    if (players.Max(x => x.XP) == players.ElementAt(i).XP)
                    {
                        players.ElementAt(i).isWiner = true;
                    }
                    else
                    {
                        players.ElementAt(i).isLoser = true;
                    }
               await GameHub.GlobalContext.Clients.Group(Id).SendAsync("clientInit", Common.rooms.Find(x => x.Id == Id.ToUpper()));
            }
        }
        public void addCard()
        {
            if (current != null&& roomDeck.Count>0)
            {
                current.Cards.Add(roomDeck.First());
                roomDeck.RemoveAt(0);
            }
        }
        public void noDefenseFight()
        {
            switch (Attack.Type)
            {
                case CardType.Attack:
                        next.XP -= Attack.Points;
                    break;
                case CardType.Thief:
                    next.XP -= Attack.Points;
                    next.XP += Attack.Points;
                    break;
                case CardType.Sabotage:

                    if (next.Cards.Any(x => x.Type == CardType.Sabotage))
                    {
                        next.Cards.Remove(next.Cards.First(x => x.Type == CardType.Sabotage));
                    }
                    else if (next.Cards.Any(x => x.Type == CardType.Resources))
                    {
                        next.Cards.Remove(next.Cards.First(x => x.Type == CardType.Resources));
                    }
                    else
                    {
                        next.Cards.Remove(next.Cards.First());
                    }
                    break;
            }
            addCard();
            Attack = Defend = null;
        }
        public void fight()
        {
            addCard();
            int res;
            if (Attack!=null&&Defend!=null&&Attack.Type == Defend.Type)
            {
                switch (Attack.Type)
                {
                    case CardType.Attack:
                         res = Attack.Points - Defend.Points;
                        if(res >0)
                            next.XP-=res;
                        break;
                    case CardType.Thief:
                         res = Attack.Points - Defend.Points;
                        if (res > 0)
                        {
                            next.XP -= res;
                            next.XP += res;
                        }
                        break;
                    case CardType.Sabotage:
                 
                        if (next.Cards.Any(x=>x.Type == CardType.Sabotage))
                        {
                            next.Cards.Remove(next.Cards.First(x => x.Type == CardType.Sabotage));
                        }
                        else if(next.Cards.Any(x => x.Type == CardType.Resources))
                        {
                            next.Cards.Remove(next.Cards.First(x => x.Type == CardType.Resources));
                        }
                        else
                        {
                            if(next.Cards.Count>0)
                            next.Cards.Remove(next.Cards.First());
                        }
                        break;
                }
                Attack = Defend = null;
                // Turn();
                counter.seconds = 0;
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
