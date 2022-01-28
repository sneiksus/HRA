using hra_back.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hra_back.Models
{
    public class Counter
    {
       // IHubContext<GameHub> hubContext;

        string roomCode;
        public int seconds { get; set; }

        public Counter(string code)
        {
            this.roomCode = code;
            seconds = 30;
            var timer1 = new Timer(_ => {
                seconds--;
               GameHub.GlobalContext.Clients.Group(roomCode).SendAsync("clientInit", Common.rooms.Find(x => x.Id == roomCode.ToUpper()));
            },null, 0, 1000);
        }
    }
}
