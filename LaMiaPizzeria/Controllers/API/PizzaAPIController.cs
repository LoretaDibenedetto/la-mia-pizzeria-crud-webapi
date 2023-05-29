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

        [HttpGet("{id}")]
        public IActionResult SearchById(int id) 
        { 
             using(var db = new PizzaContext())

                {
                  Pizza? pizzaIdToSearch = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if(pizzaIdToSearch != null)
                {
                    return Ok(pizzaIdToSearch);

                }
                 return NotFound();

                }

        
        }


        [HttpPost]
        public IActionResult Create([FromBody] Pizza pizza)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else { 

                using(var db = new PizzaContext())
                {
                    db.Pizzas.Add(pizza);
                    db.SaveChanges();

                    return Ok();
                }
           }
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Pizza data)
        {
            using (PizzaContext db = new PizzaContext())
            {
               
              Pizza? pizzaIdToEdit = db.Pizzas.Where(pizza => pizza.Id == id).FirstOrDefault();

                if (pizzaIdToEdit != null)
                {
                    
                    return Ok();
                }
                else
                {
                    
                    return NotFound();
                }
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (PizzaContext context = new PizzaContext())
            {
                Pizza? profileToDelete = context.Pizzas.Where(profile => profile.Id == id).FirstOrDefault();
                if (profileToDelete != null)
                {
                    context.Pizzas.Remove(profileToDelete);
                    context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }

    }
}
