﻿using System;
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
        private readonly rankingRepository RankingRepository;
        public rankingController(rankingRepository RankingRepository)
        {
            this.RankingRepository = RankingRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRanking()
        {
            return Ok(await RankingRepository.GetAllRanking());
        }


        [HttpPost]
        public async Task<IActionResult> CreateLocalizacion(ranking score)
        {
            if (score == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var created = await RankingRepository.InsertarRanking(score);
            return Created("Creado!", created);
        }




        [HttpDelete("{ciudad}")]
        public async Task<IActionResult> DeleteLocalizacion(string ciudad)
        {


            var deleted = await RankingRepository.DeleteLocalizacion(new ranking { ciudad = ciudad });
            return Created("Eliminado!", deleted);
        }
    }
}

