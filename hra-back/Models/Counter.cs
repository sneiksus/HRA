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
        Timer t;
        public Action turn;
        string roomCode;
        public int seconds { get; set; }

        public  void stop()
        {
           /// t.Change(Timeout.Infinite, Timeout.Infinite);
             this.turn();
        }

        public Counter(string code)
        {
            this.roomCode = code;
            seconds = 30;
            /*t = new Timer(_ => {
                seconds--;
               GameHub.GlobalContext.Clients.Group(roomCode).SendAsync("clientInit", Common.rooms.Find(x => x.Id == roomCode.ToUpper()));
                if (seconds < 0)
                {
                    this.stop();
                    
                }
            },null, 0, 1000);*/
            Task.Run(async () =>
            {
                while (seconds > 0)
                {
                    Thread.Sleep(1000);
                    seconds--;
                    await GameHub.GlobalContext.Clients.Group(roomCode).SendAsync("clientInit", Common.rooms.Find(x => x.Id == roomCode.ToUpper()));
                }
                this.stop();
            });
        }
    }
}
