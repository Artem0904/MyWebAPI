using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeverageController(IBeverageService beveragesService) : ControllerBase
    {
        private readonly IBeverageService beveragesService = beveragesService;

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(beveragesService.GetAll());
        }

        [HttpGet("{id:int}")]
        //[Authorize] // based on cookies
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] // based on JWT
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return Ok(await beveragesService.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromForm] BeverageCreateModel model)
        {
            beveragesService.Create(model);
            return Ok();
        }


        [HttpPut]
        public IActionResult Edit([FromBody] BeverageDto model)
        {
            beveragesService.Edit(model);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            beveragesService.Delete(id);
            return Ok();
        }
    }
}
