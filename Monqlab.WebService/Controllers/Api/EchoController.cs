using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monqlab.WebService.Entities;
using Monqlab.WebService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Controllers.Api
{
    [Route("api")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        private readonly IFactory<MonqlabDbContext> _contextFactory;

        public EchoController(IFactory<MonqlabDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        /// <summary>
        /// Method for polling the internal state of the system. If the service is ready to work, it will return the current date
        /// </summary>
        /// <returns>Current Date in UTC</returns>
        [HttpGet("echo")]
        public string Echo() 
        {
            using (var context = _contextFactory.Create())
            {
                context.SentMessages.FirstOrDefault();
            }
            return DateTime.UtcNow.ToString("s");
        }
    }
}
