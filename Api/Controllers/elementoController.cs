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
            return Ok(await ElementoRepository.GetAllElemento());
        }

    }
}
