using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQConections;
using Interfaces;
using DigizuiteApi.Models;

namespace DigizuiteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        RabbitMQConections.RabbitMQ RabbitMQ { get; set; }
        public List<Storeage> Storeages { get; }

        public WeatherForecastController(RabbitMQConections.RabbitMQ rabbitMQ, List<Storeage> storeages )
        {
            RabbitMQ = rabbitMQ;
            Storeages = storeages;
        }
        [HttpPost]
        public async Task<IActionResult> Test(Storeage message)
        {
            Storeages.Add(message);
            RabbitMQ.PublicMessage<IMessage>(message.Message);
            return Ok();
        }
        [HttpPost("Metadata")]
        public async Task<IActionResult> AddMetadata(Metadata message)
        {
            Storeage storeage = Storeages.FirstOrDefault(x => x.Metadata.MessageId == message.MessageId);
            if (storeage == null)
            {
                return NotFound();
            }
            storeage.Metadata = message;
            Console.WriteLine();
            return Ok("Metadata Addet");
        }
    }
}
