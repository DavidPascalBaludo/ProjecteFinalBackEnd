using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Elmentoss que contiene todos los métodos SQL querys
    /// </summary>
    public class elementoRepository
    {
        private PosgreSQLConfig connexionString;
        public elementoRepository(PosgreSQLConfig connectionString)
        {
            this.connexionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<elemento>> GetAllElemento()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.elemento";

            return await db.QueryAsync<elemento>(sql, new { });

        }
    }
}
