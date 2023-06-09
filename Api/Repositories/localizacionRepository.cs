using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Localizacion que contiene todos los m�todos SQL querys
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

            var sql = @"SELECT ciudad, longitud, latitud FROM public.localizacion WHERE ciudad = @ciudad";

            return await db.QueryFirstOrDefaultAsync<localizacion>(sql, new { ciudad = ciudad });
        }

        public async Task<bool> InsertLocalizacion(localizacion loc)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO public.localizacion ( ciudad, latitud, longitud ) VALUES (@ciudad, @latitud, @longitud)";

            var result = await db.ExecuteAsync(sql, new { loc.ciudad, loc.latitud, loc.longitud });
            return result > 0;
        }

        public async Task<bool> UpdateLocalizacion(localizacion loc)
        {
            var db = dbConnection();

            var sql = @"UPDATE public.localizacion
                        SET latitud  = @latitud,
                            longitud = @longitud
                        WHERE ciudad = @ciudad
                        ";

            var result = await db.ExecuteAsync(sql, new { latitud = loc.latitud, longitud = loc.longitud, ciudad = loc.ciudad });
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