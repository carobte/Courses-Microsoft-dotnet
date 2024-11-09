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

    // PUT

    // DELETE
}