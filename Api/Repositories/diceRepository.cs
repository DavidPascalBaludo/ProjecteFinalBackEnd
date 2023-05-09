using Dapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Configuration;
using TodoApi.Model;
using TodoApi.Models;
using Microsoft.Extensions.Configuration;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Elmentoss que contiene todos los métodos SQL querys
    /// </summary>
    public class DiceRepository
    {
        private readonly MyContext _context;
        private readonly IConfiguration _configuration;

        public DiceRepository(MyContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string ObtenerClave()
        {
            var clave = _context.Dice.FirstOrDefault()?.Valor ?? _configuration.GetValue<string>("ClaveDefault");
            if (string.IsNullOrEmpty(clave))
            {
                throw new Exception("No se ha encontrado ninguna clave en la base de datos ni se ha especificado una clave predeterminada en la configuración.");
            }

            return clave;
        }
    }
}
