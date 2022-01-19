﻿using hra_back.Models;
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
        }

        public async Task roomConnection(string code)
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId+" lobby");
            if (Common.rooms.Find(x => x.Id == code.ToUpper()) != null)
            {
                if (Common.rooms.Find(x => x.Id == code.ToUpper()).players.Count >= 4)
                    await Clients.Caller.SendAsync("FilledRoom");
                Common.rooms.First(x => x.Id == code.ToUpper()).players.AddLast(new Player { Id = Context.ConnectionId, Nick = "Player3225", Cards = new List<Card>(), XP = 500 });
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
            System.Diagnostics.Debug.WriteLine(Common.rooms.Count + "changeNick");
            var res = Common.rooms.Find(x => x.Id == roomId.ToUpper());
            for (LinkedListNode<Player> it = res.players.First; it != null;)
            {
                LinkedListNode<Player> next = it.Next;
                if (it.Value.Nick != Context.ConnectionId)
                    it.Value.Nick = nick;
                it = next;
            }
            await Clients.All.SendAsync("roomPlayers", res.players.ToArray());
        }
    }
}
