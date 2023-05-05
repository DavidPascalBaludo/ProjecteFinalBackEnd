using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Jugador que contiene todos los métodos SQL querys
    /// </summary>
    public class jugadorRepository
    {
        private PosgreSQLConfig connexionString;
        public jugadorRepository(PosgreSQLConfig connectionString)
        {
            connexionString = connectionString;
        } 

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<jugador>> GetAllJugador()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.jugador";

            return await db.QueryAsync<jugador>(sql, new { });

        }

        //public async Task<jugador> GetJugadorDetails(string nombre_Jugador, string contraseña)
        //{
        //    var db = dbConnection();

        //    //if (this.nombre_Jugador != nombre_Jugador)
        //    //{

        //    //}
        //    var sql = @"SELECT * FROM public.jugador WHERE nombre_Jugador = '@nombre_Jugador' AND contraseña = '@contraseña'";

        //    return await db.QueryFirstOrDefaultAsync<jugador>(sql, new { nombre_Jugador = nombre_Jugador, contraseña = contraseña});
        //}

        //public async Task<bool> InsertLocalizacion(localizacion loc)
        //{
        //    var db = dbConnection();

        //    var sql = @"
        //                INSERT INTO public.localizacion ( nombre_Jugador, contraseña, nivel_Actual, ciudad) VALUES (@ciudad, @latitud, @longitud)";

        //    var result = await db.ExecuteAsync(sql, new { loc.ciudad, loc.latitud, loc.longitud });
        //    return result > 0;
        //}

        //public async Task<bool> UpdateLocalizacion(localizacion loc)
        //{
        //    var db = dbConnection();

        //    var sql = @"UPDATE  public.localizacion
        //                SET ciudad = @ciudad,
        //                    latitud  = @latitud,
        //                    longitud = @longitud,
        //                WHERE ciudad = @ciudad;
        //                ";

        //    var result = await db.ExecuteAsync(sql, new { loc.ciudad, loc.latitud, loc.longitud });
        //    return result > 0;
        //}

        //public async Task<bool> DeleteJugador(string jugador)
        //{
        //    var db = dbConnection();

        //    var sql = @"
        //                DELETE FROM public.jugador
        //                WHERE nombre_Jugador = @jugador
                            
        //                ";

        //    var result = await db.ExecuteAsync(sql, new { jugador = jugador });
        //    return result > 0;
        //}
    }
}