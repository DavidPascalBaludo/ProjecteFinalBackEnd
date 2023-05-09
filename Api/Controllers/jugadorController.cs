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
        private readonly rankingRepository RankingRepository;
        public jugadorController(jugadorRepository JugadorRepository, rankingRepository RankingRepository)
        {
            this.JugadorRepository = JugadorRepository;
            this.RankingRepository = RankingRepository;
        }
        //Metodo que muestra todos los jugadoes con su nivel 
        [HttpGet]
        public async Task<IActionResult> GetAllJugador()
        {
            return Ok(await JugadorRepository.GetAllJugador());
        }
        //Metodo qu muestra solo un jugador por su nombre 
        [HttpGet("{nombre_Jugador}")]
        public async Task<IActionResult> GetJugadorDetailsAll(string nombre_Jugador)
        {
            return Ok(await JugadorRepository.GetJugadorDetailsAll(nombre_Jugador));
        }
        //Metodo que muestra si el jugador con la contraseña y el nombre existe devolviendo 0 en caso de que no exista el nombre 1 si la contraseña es incorrecta y 2 si es correcta ambas
        [HttpGet("{nombre_Jugador},{contraseña}")]
        public async Task<IActionResult> GetJugadorDetails(string nombre_Jugador, string contraseña)
        {
            return Ok(await JugadorRepository.GetJugadorDetails(nombre_Jugador, contraseña));
        }
        //Metodo que inserta jugadores 

        [HttpPost]
        public async Task<IActionResult> CreateJugador([FromBody] jugador jugador)
        {
            if (jugador == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await JugadorRepository.InsertJugador(jugador);
            return Created("Creado!", created);
        }

        //Metodo que actualiza jugadores
        [HttpPut("{nombre_Jugador},{nivel_Actual}")]
        public async Task<IActionResult> UpdateJugador(string nombre_Jugador, int nivel_Actual)
        {
            if (nombre_Jugador == null || nivel_Actual < 0)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updated = await JugadorRepository.UpdateJugador(nombre_Jugador, nivel_Actual);
            return Created("Actualizado!", updated);
        }

        // Borrar nombre jugador
        [HttpDelete("{nombre_Jugador}")]
        public async Task<IActionResult> DeleteJugador(string nombre_Jugador)
        {
            await RankingRepository.DeleteRanking(nombre_Jugador);

            var deleted = await JugadorRepository.DeleteJugador(nombre_Jugador);
            return Created("Eliminado!", deleted);
        }
    }
}
