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
    public class DescifradoController : ControllerBase
    {
        private readonly DiceRepository _diceRepository;

        public DescifradoController(DiceRepository diceRepository)
        {
            _diceRepository = diceRepository;
        }

        [HttpPost]
        public ActionResult<string> DescifrarTexto(string textoCifrado)
        {
            var clave = _diceRepository.ObtenerClave();
            var resultado = DescifradoXOR(textoCifrado, clave);
            return Ok(resultado);
        }

        private string DescifradoXOR(string textoCifrado, string clave)
        {
            string resultado = "";
            for (int i = 0; i < textoCifrado.Length; i++)
            {
                int caracter = textoCifrado[i] ^ clave[i % clave.Length];
                resultado += (char)caracter;
            }
            return resultado;
        }
    }
}

