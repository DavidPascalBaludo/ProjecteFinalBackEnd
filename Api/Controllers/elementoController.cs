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
    /// Controlador para elementos
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
        //Extrae todos los elemenntos de elemento y los muestra
        public async Task<IActionResult> GetAllElemento()
        {
            return Ok(await ElementoRepository.GetAllElemento());
        }

    }
}
