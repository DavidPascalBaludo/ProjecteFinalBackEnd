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
    }
}
