using ApiCatalgoAdocao.Requests;
using ApiCatalgoAdocao.Services.Interfaces;
using ApiCatalgoAdocao.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalgoAdocao.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AdocaoController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AdocaoController(IAnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalViewModel>>> GetAll([FromQuery, Range(0, 50)] int pagina = 1,
                                                                    [FromQuery, Range(0, int.MaxValue)] int quantidade = 5)
        {
            var result = await _animalService.GetAll(pagina, quantidade);

            if (!result.Any())
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AnimalViewModel>> Get([FromRoute] Guid id)
        {
            var result = await _animalService.Get(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalViewModel>> Add([FromBody] AnimalRequest animal)
        {
            try
            {
                var result = await _animalService.Add(animal);

                if (result == null)
                    return NoContent();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return UnprocessableEntity("Já existe um animal com esse nome dessa tutora!");
            }
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Update([FromRoute] Guid id, [FromBody] AnimalRequest animal)
        {
            try
            {
                await _animalService.Update(id, animal);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound("Animal não existe!");
            }

        }

        [HttpPatch("{id:guid}/status/{status:int}")]
        public async Task<ActionResult> UpdateStatus([FromRoute] Guid id, [FromRoute] int status)
        {
            try
            {
                await _animalService.UpdateStatus(id, status);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound("Animal não existe!");
            }
        }

        [HttpPatch("{id:guid}/porte/{porte:int}")]
        public async Task<ActionResult> UpdatePorte([FromRoute] Guid id, [FromRoute] int porte)
        {
            try
            {
                await _animalService.UpdatePorte(id, porte);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound("Animal não existe!");
            }

        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                await _animalService.Delete(id);
                return Ok();
            }
            catch (Exception)
            {

                return NotFound("Animal não existe!");
            }
        }
    }
}
