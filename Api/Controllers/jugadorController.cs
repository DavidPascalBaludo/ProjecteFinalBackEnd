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
    /// Controlador para Jugador
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class jugadorController : ControllerBase
    {
        private readonly jugadorRepository JugadorRepository;
        public jugadorController(jugadorRepository JugadorRepository)
        {
            this.JugadorRepository = JugadorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllJugador()
        {
            return Ok(await JugadorRepository.GetAllJugador());
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetJugadorDetails(string nombre_Jugador, string contraseña)
        //{
        //    return Ok(await JugadorRepository.GetJugadorDetails(nombre_Jugador, contraseña));
        //}

        //[HttpPost]
        //public async Task<IActionResult> CreateLocalizacion([FromBody] localizacion loc)
        //{
        //    if (loc == null)
        //    {
        //        return BadRequest();


        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var created = await JugadorRepository.InsertLocalizacion(loc);
        //    return Created("Creado!", created);
        //}


        //[HttpPut]
        //public async Task<IActionResult> UpdateLocalizacion([FromBody] localizacion loc)
        //{
        //    if (loc == null)
        //    {
        //        return BadRequest();


        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var updated = await JugadorRepository.UpdateLocalizacion(loc);
        //    return Created("Actualizado!", updated);
        //}

        //// Borrar nombre jugador
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteJugador(string nombre_Jugador)
        //{

        //    var deleted = await JugadorRepository.DeleteJugador(nombre_Jugador);
        //    return Created("Eliminado!", deleted);
        //}
    }
}
