using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Localizacion que contiene todos los métodos SQL querys
    /// </summary>
    public class localizacionRepository
    {
        private PosgreSQLConfig connexionString;
        public localizacionRepository(PosgreSQLConfig connectionString)
        {
            connexionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<localizacion>> GetAllLocalizacion()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.localizacion";

            return await db.QueryAsync<localizacion>(sql, new { });
        }

        public async Task<localizacion> GetLocalizacionDetails(string ciudad)
        {
            var db = dbConnection();

            //var sql = @"SELECT ciudad, longitud, latitud FROM public.localizacion WHERE ciudad = @Id";
            var sql = @"SELECT ciudad, longitud, latitud FROM public.localizacion WHERE ciudad = @ciudad";

            return await db.QueryFirstOrDefaultAsync<localizacion>(sql, new { ciudad = ciudad });
        }
    }
}