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
    public class nivelController : ControllerBase
    {
        private readonly nivelRepository NivelRepository;
        public nivelController(nivelRepository NivelRepository)
        {
            this.NivelRepository = NivelRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNivel()
        {
            return Ok(await NivelRepository.GetAllNivel());
        }

        [HttpGet("{id_Nivel}")]
        public async Task<IActionResult> GetNivelDetails(int id_Nivel)
        {
            return Ok(await NivelRepository.GetNivelDetails(id_Nivel));
        }
    }
}
