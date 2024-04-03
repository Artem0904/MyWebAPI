using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzasService;

        public PizzaController(IPizzaService pizzasService)
        {
            this.pizzasService = pizzasService;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(pizzasService.GetAll());
        }

        [HttpGet("{id:int}")]
        //[Authorize] // based on cookies
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // based on JWT
        public IActionResult Get([FromRoute] int id)
        {
            return Ok(pizzasService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] CreatePizzaModel model)
        {
            pizzasService.Create(model);
            return Ok();
        }


        [HttpPut]
        public IActionResult Edit([FromBody] PizzaDto model)
        {
            pizzasService.Edit(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            pizzasService.Delete(id);
            return Ok();
        }
    }
}
