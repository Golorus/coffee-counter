using System.Collections.Generic;
using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;
using System.Text.Json;

namespace server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoffeesController : ControllerBase
    {
        private readonly CoffeesService _coffeesService;
        public CoffeesController(CoffeesService coffeesService)
        {
            _coffeesService = coffeesService;

        }
        [HttpGet]
        
        public List<Coffee> Get()
        {

            return _coffeesService.GetCoffees();
        }
        [HttpPost("/{Name}")]
        [Route("{Name}")]
        public Coffee Add(string Name)
        {
            var response = _coffeesService.addCoffee(Name);
            return response;
        }
    }
}
