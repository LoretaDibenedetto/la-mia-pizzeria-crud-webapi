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

            using (PizzaContext db = new PizzaContext())
            {
                List<Pizza> pizzas = db.Pizzas.ToList();
                return Ok(pizzas);
            }

        }

        [HttpGet]
        public IActionResult SearchByName(string name)
        {
            using(var db = new PizzaContext())
            { 
             Pizza? pizzatosearch = db.Pizzas.Where(pizza => pizza.Name.Contains(name)).FirstOrDefault();

                if (pizzatosearch != null)
                {
                    return Ok(pizzatosearch);
                }
                else 
                { 

                     return NotFound();
                 }
            }
        }


    }
}
