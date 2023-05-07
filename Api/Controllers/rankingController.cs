using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
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
    public class rankingController : ControllerBase
    {
        //Conexion con el repositorio donde tengo guardados todos los metodos.
        private readonly rankingRepository RankingRepository;
        public rankingController(rankingRepository RankingRepository)
        {
            this.RankingRepository = RankingRepository;
        }

        //Http que devuelve los datos dentro de la tabla
        [HttpGet]
        public async Task<IActionResult> GetAllRanking()
        {
            return Ok(await RankingRepository.GetAllRanking());
        }

        //Http que hace inserts segun el nombre el tiempo el nivel y la ciudad
        [HttpPost("{nombre_Jugador},{tiempo},{nivel_Guardado},{ciudad}")]
        public async Task<IActionResult> InsertarRanking(string nombre_Jugador, int tiempo, int nivel_Guardado, string ciudad)
        {
            if (nombre_Jugador == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await RankingRepository.InsertarRanking(nombre_Jugador, tiempo, nivel_Guardado, ciudad);
            return Created("Creado!", created);
        }


        //Http que borra por el nombre del jugador

        [HttpDelete("{nombre_Jugador}")]
        public async Task<IActionResult> DeleteRanking(string nombre_Jugador)
        {
            var deleted = await RankingRepository.DeleteRanking(nombre_Jugador);
            return Created("Eliminado!", deleted);
        }
    }
}

