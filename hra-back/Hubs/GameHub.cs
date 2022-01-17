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
            await Clients.Caller.SendAsync("getID", Context.ConnectionId);
        }

        public async Task roomConnection(string code)
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId+" lobby");
            if (Common.rooms.Find(x => x.Id == code.ToUpper()) != null)
            {
                if (Common.rooms.Find(x => x.Id == code.ToUpper()).players.Count >= 4)
                    await Clients.Caller.SendAsync("FilledRoom");
                Common.rooms.First(x => x.Id == code.ToUpper()).players.AddLast(new Player { Id = Context.ConnectionId, Nick = "Player", Cards = new List<Card>(), XP = 500 });
                await Groups.AddToGroupAsync(Context.ConnectionId, code);
                await Clients.Caller.SendAsync("GoInRoom");
                await sendPlayersInRoom(Context.ConnectionId, Common.rooms.Find(x => x.Id == code.ToUpper()));
            }
            else
                await Clients.Caller.SendAsync("NotFoundRoom");

        }

        public async Task sendPlayersInRoom(string connectionId, Room r)
        {
            System.Diagnostics.Debug.WriteLine(Context.ConnectionId);
            await Clients.Client(connectionId).SendAsync("refreshRoomData", r.players.ToList());
        }
    }
}
