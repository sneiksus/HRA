using hra_back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace hra_back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        List<Room> rooms;

        public MainController()
        {
            rooms = new List<Room>();
            //roomRemover(TimeSpan.FromSeconds(7));
            /*var timer1 = new Timer(_ => {
                if (rooms.Count > 0)
                    rooms.RemoveAll(x => x.players.Count <= 0);
                System.Diagnostics.Debug.WriteLine("Removed\n");
            }, null, 0, 2000);*/
        }

        [HttpGet("bon")]
        public IActionResult createRoom() {
            rooms.Add(new Room { Id = generateRoomId(), players = new LinkedList<Player>() });
            return Ok();
        }
        [HttpPost("con")]
        public IActionResult Connect([FromForm] string code)
        {
            if (rooms.Find(x => x.Id == code.ToUpper()) != null)
                return Ok();
            else
                return BadRequest();
        }

        [HttpPost("[action]")]
        public string Post([FromForm] int id=5) { return "Poi, "+id.ToString(); }

        private string generateRoomId() { return Guid.NewGuid().ToString("N").ToUpper().Substring(0, 5); }
        private async void roomRemover(TimeSpan timeout)
        {
            System.Diagnostics.Debug.WriteLine("Removed\n");
            await Task.Delay(timeout).ConfigureAwait(false);
            rooms.RemoveAll(x => x.players.Count <= 0);
            roomRemover(TimeSpan.FromSeconds(7));
        }
    }
}
