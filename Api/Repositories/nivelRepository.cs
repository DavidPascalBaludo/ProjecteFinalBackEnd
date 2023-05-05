using Api.Models;
using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Car que contiene todos los métodos SQL querys
    /// </summary>
    public class nivelRepository
    {
        private PosgreSQLConfig connexionString;
        public nivelRepository(PosgreSQLConfig connectionString)
        {
            this.connexionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<nivel>> GetAllNivel()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.nivel";

            return await db.QueryAsync<nivel>(sql, new { });

        }

        public async Task<nivel> GetNivelDetails(int id_Nivel)
        {
            var db = dbConnection();
            
            var sql = @"SELECT * FROM public.nivel WHERE id_Nivel = @id_Nivel";

            return await db.QueryFirstOrDefaultAsync<nivel>(sql, new { id_Nivel });
        }
    }
}

