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
        //Hace la conexion con los distintos Respitorios y ayuda ha hacer la conexion a la BDD
        private PosgreSQLConfig connexionString;
        public rankingRepository(PosgreSQLConfig connectionString)
        {
            this.connexionString = connectionString;
        }
        //Conexion BDD
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }
        //Muestra todos los rankings en la BDD
        public async Task<IEnumerable<ranking>> GetAllRanking()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.ranking";

            return await db.QueryAsync<ranking>(sql, new { });

        }
        //Inserta los nuevos rankings en la BDD
        public async Task<bool> InsertarRanking(string nombre_Jugador, int tiempo, int nivel_Guardado, string ciudad)
        {
            var db = dbConnection();

            //Te dara false si el nombre del jugador no consta en la BDD
            var sql = @"SELECT * FROM public.jugador WHERE nombre_Jugador = @nombre_Jugador";

            var resultadoJugador= await db.QueryFirstOrDefaultAsync<localizacion>(sql, new {nombre_Jugador });

            if (resultadoJugador == null) return false;

            //Inserta los resultado si las condiciones se cumplen

            sql = @"INSERT INTO ranking (nombre_Jugador, tiempo, nivel_Guardado, ciudad) values (@nombre_Jugador, @tiempo, @nivel_Guardado, @ciudad )";

            var result = await db.ExecuteAsync(sql, new { nombre_Jugador, tiempo, nivel_Guardado, ciudad});
            return result > 0;
        }

        // Borra el ranking con el nombre del jugador existente en la BDD
        public async Task<bool> DeleteLocalizacion(string nombre_Jugador)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.jugador WHERE nombre_Jugador = @nombre_Jugador";

            var resultadoJugador = await db.QueryFirstOrDefaultAsync<localizacion>(sql, new {nombre_Jugador });

            if (resultadoJugador == null) return false;

            sql = @"DELETE FROM public.ranking WHERE nombre_Jugador = @nombre_Jugador";

            var result = await db.ExecuteAsync(sql, new {nombre_Jugador});
            return result > 0;
        }


    }
}

