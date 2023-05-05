using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data.Repositories;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    /// <summary>
    /// Controlador para Localizacions
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class elementoController : ControllerBase
    {
        private readonly elementoRepository ElementoRepository;
        public elementoController(elementoRepository ElementoRepository)
        {  

            this.ElementoRepository = ElementoRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllLocalizacion()
        {
            return Ok(await ElementoRepository.GetAllLocalizacion());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocalizacionDetails(string ciudad)
        {
            return Ok(await ElementoRepository.GetLocalizacionDetails(ciudad));
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocalizacion([FromBody] localizacion loc)
        {
            if (loc == null)
            {
                return BadRequest();


            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await ElementoRepository.InsertLocalizacion(loc);
            return Created("Creado!", created);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateLocalizacion([FromBody] localizacion loc)
        {
            if (loc == null)
            {
                return BadRequest();


            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await ElementoRepository.UpdateLocalizacion(loc);
            return Created("Actualizado!", updated);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalizacion(string ciudad)
        {


            var deleted = await ElementoRepository.DeleteLocalizacion(new localizacion { ciudad = ciudad });
            return Created("Eliminado!", deleted);
        }
    }
}
