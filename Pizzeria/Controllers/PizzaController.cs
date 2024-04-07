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
    public class PizzaController(IPizzaService pizzasService) : ControllerBase
    {
        private readonly IPizzaService pizzasService = pizzasService;

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            return Ok(await pizzasService.GetAll());
        }

        [HttpGet("{id:int}")]
        //[Authorize] // based on cookies
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // based on JWT
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await pizzasService.Get(id));
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

        [HttpGet("pizzaSizes")]
        public IActionResult GetCategories()
        {
            return Ok(pizzasService.GetAllPizzaSizes());
        }
    }
}
