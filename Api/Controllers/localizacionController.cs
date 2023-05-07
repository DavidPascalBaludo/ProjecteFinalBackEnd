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
    /// Controlador para Localizacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class localizacionController : ControllerBase
    {
        private readonly localizacionRepository LocalizacionRepository;
        public localizacionController(localizacionRepository LocalizacionRepository)
        {
            this.LocalizacionRepository = LocalizacionRepository;
        }
        //Devuelve todos los valores de Localizacion
        [HttpGet]
        public async Task<IActionResult> GetAllLocalizacion()
        {
            return Ok(await LocalizacionRepository.GetAllLocalizacion());
        }

        [HttpGet("{ciudad}")]
        public async Task<IActionResult> GetLocalizacionDetails(string ciudad)
        {
            return Ok(await LocalizacionRepository.GetLocalizacionDetails(ciudad));
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

            var created = await LocalizacionRepository.InsertLocalizacion(loc);
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

            var updated = await LocalizacionRepository.UpdateLocalizacion(loc);
            return Created("Actualizado!", updated);
        }


        [HttpDelete("{ciudad}")]
        public async Task<IActionResult> DeleteLocalizacion(string ciudad)
        {


            var deleted = await LocalizacionRepository.DeleteLocalizacion(new localizacion { ciudad = ciudad });
            return Created("Eliminado!", deleted);
        }
    }
}
