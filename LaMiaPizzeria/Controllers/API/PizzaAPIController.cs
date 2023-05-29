using LaMiaPizzeria.Database;
using LaMiaPizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaAPIController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetPizzas()
        {

            using(PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizzas.ToList();
                return Ok(pizzas);
            }

        }

        


    }
}
