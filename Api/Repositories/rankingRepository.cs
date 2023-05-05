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
    public class rankingRepository
    {
        private PosgreSQLConfig connexionString;
        public rankingRepository(PosgreSQLConfig connectionString)
        {
            this.connexionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<localizacion>> GetAllRanking()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.ranking";

            return await db.QueryAsync<localizacion>(sql, new { });

        }

        public async Task<bool> InsertarRanking(ranking score)
        {
            var db = dbConnection();

            var sql = @"INSERT INTO ranking (nombre_Jugador, tiempo, nivel_Guardado, ciudad) values (@nombre_Jugador, @tiempo, @nivel_Guardado, @ciudad )";

            var result = await db.ExecuteAsync(sql, new { score.nombre_Jugador, score.tiempo, score.nivel_Guardado, score.ciudad});
            return result > 0;
        }

        public async Task<bool> DeleteLocalizacion(localizacion loc)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE FROM public.localizacion
                        WHERE ciudad = @ciudad
                            
                        ";

            var result = await db.ExecuteAsync(sql, new { ciudad = loc.ciudad });
            return result > 0;
        }


    }
}

