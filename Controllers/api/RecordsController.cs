using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XSSTracker.Hubs;
using XSSTracker.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace XSSTracker.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IHubContext<RecordsHub> _recordsHub;

        public RecordsController(IHubContext<RecordsHub> recordsHub)
        {
            _recordsHub = recordsHub;
        }

        // POST api/<RecordsController>
        [HttpPost]
        public void Post([FromBody] Record record)
        {
            Console.WriteLine(record.URL);
            Console.WriteLine(record.XSSClass);
            _recordsHub.Clients.All.SendAsync("ReceiveMessage", record.URL, record.XSSClass);
        }

    }
}
