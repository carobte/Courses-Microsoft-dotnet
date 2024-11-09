using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    public PizzaController()
    {
    }

    // GET all
    [HttpGet]
    //ActionResult is the base class for all action results.
    public ActionResult<List<Pizza>> GetAll()
    {
        return PizzaService.GetPizzas();
    }

    // GET by Id
    [HttpGet("{id}")]
    public ActionResult<Pizza?> GetId(int id)
    {
        var pizza = PizzaService.Get(id);
        return pizza == null ? NotFound() : Ok(pizza);
    }

    // POST
    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        // CreatedAtAction not only returns a 201(created) but also includes the location of the 
        // newly created resource in the response header (in the Location field)
        return CreatedAtAction(nameof(GetId), new { id = pizza.Id }, pizza);
    }

    // PUT

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest(); // id is different from the proporcioned pizza.Id 

        var existingPizza = PizzaService.Get(id);
        if (existingPizza == null)
            return NotFound(); // no pizza found

        PizzaService.Update(pizza);

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null)
            return NotFound(); // no pizza found

        PizzaService.Delete(id);

        return NoContent();
    }
}