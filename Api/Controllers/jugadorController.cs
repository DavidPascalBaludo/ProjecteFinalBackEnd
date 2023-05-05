﻿using System;
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

        [HttpGet("{nombre_Jugador},{contraseña}")]
        public async Task<IActionResult> GetJugadorDetails(string nombre_Jugador, string contraseña)
        {
            return Ok(await JugadorRepository.GetJugadorDetails(nombre_Jugador, contraseña));
        }

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

            var deleted = await JugadorRepository.DeleteJugador(nombre_Jugador);
            return Created("Eliminado!", deleted);
        }
    }
}
