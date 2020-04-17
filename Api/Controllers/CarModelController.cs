using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarModelController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Ford F-150 Raptor", "AMC Gremlin", "Volkswagen Beetle", "McLaren Senna" ,"AMC Gremlin"
        };

        private readonly ILogger<CarModelController> _logger;

        public CarModelController(ILogger<CarModelController> logger)
        {
            _logger = logger;
        }

       


        [HttpGet]
        public IEnumerable<CarModel> Get()
        {
            
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new CarModel
            {
                Date = DateTime.Now.AddDays(index),
                Model = rng.Next(2010, 2019),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            
        }

        
    }
}
