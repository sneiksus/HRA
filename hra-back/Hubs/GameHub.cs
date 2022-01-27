using hra_back.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hra_back.Hubs
{
    public class GameHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId + " connect");
           // await Clients.Caller.SendAsync("getID", Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception ex)
        {
           // await Clients.Caller.SendAsync("getID", Context.ConnectionId);
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId + " disconnect");
            for(int i=0;i<Common.rooms.Count;i++)
            {
                
                if (Common.rooms[i].RemovePlayer(Context.ConnectionId))
                {
                    
                    await getPlayersInRoom(Common.rooms[i].Id);
                    return;
                }
            }
              
        }

        public async Task roomConnection(string code="0")
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId+" lobby");
            if (Common.rooms.Find(x => x.Id == code.ToUpper()) != null)
            {
                if (Common.rooms.Find(x => x.Id == code.ToUpper()).players.Count >= 4)
                    await Clients.Caller.SendAsync("FilledRoom");
                Common.rooms.First(x => x.Id == code.ToUpper()).players.AddLast(new Player { Id = Context.ConnectionId, Nick = "Player"+ Common.rooms.First(x => x.Id == code.ToUpper()).players.Count.ToString(), Cards = new List<Card>(), XP = 500 });
                await Groups.AddToGroupAsync(Context.ConnectionId, code);
                await Clients.Caller.SendAsync("GoInRoom");
                await sendPlayersInRoom(Context.ConnectionId, Common.rooms.Find(x => x.Id == code.ToUpper()));
            }
            else
                await Clients.Caller.SendAsync("NotFoundRoom");

        }

        public async Task sendPlayersInRoom(string connectionId, Room r)
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId + "players");
            await Clients.All.SendAsync("roomPlayers", r.players.ToList());
        }

        public async Task getPlayersInRoom(string roomId)
        {
            System.Diagnostics.Debug.WriteLine(Common.rooms.Count+ "playersget");
            var res = Common.rooms.Find(x => x.Id == roomId.ToUpper());
            await Clients.All.SendAsync("roomPlayers", res.players.ToArray());
          //  res.players.AddLast(new Player() { Id = "ggth", Nick = "fgg", Cards = new List<Card>(), XP = 500 });
        }
        
        public async Task changeNick(string roomId, string nick)
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId + "changeNick");
            var res = Common.rooms.Find(x => x.Id == roomId.ToUpper());
            for (LinkedListNode<Player> it = res.players.First; it != null;)
            {
                System.Diagnostics.Debug.WriteLine(it.Value .Id+ " "+ it.Value.Nick);
                LinkedListNode<Player> next = it.Next;
                if (it.Value.Id == Context.ConnectionId)
                {
                    it.Value.Nick = nick;
                    it.Value.isReady = true;
                }
                it = next;
            }
            await Clients.All.SendAsync("roomPlayers", res.players.ToArray());
        }

        //-------------------------------GAME_CONTROL---------------------------

        public async Task PlayInit(string roomCode)
        {
            Common.rooms.Find(x => x.Id == roomCode.ToUpper()).AddCards(Context.ConnectionId, Common.cards);
            await Clients.Group(roomCode).SendAsync("clientInit", Common.rooms.Find(x => x.Id == roomCode.ToUpper()));
            Task.Run(() => Play(roomCode));
        }


        private void Play(string roomCode)
        {
            
        }
    }
}
