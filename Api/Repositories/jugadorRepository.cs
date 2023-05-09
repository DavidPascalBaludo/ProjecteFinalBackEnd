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
        //Coger todos los jugadores
        public async Task<IEnumerable<jugador>> GetAllJugador()
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.jugador";

            return await db.QueryAsync<jugador>(sql, new { });

        }
        //Coger un jugador Especifico
        public async Task<object> GetJugadorDetailsAll(string nombre_Jugador)
        {
            var db = dbConnection();
     
            var sql = @"SELECT nombre_Jugador, nivel_Actual, ciudad FROM public.jugador WHERE nombre_Jugador = @nombre_Jugador";

            return await db.QueryFirstOrDefaultAsync(sql, new { nombre_Jugador = nombre_Jugador });
        }
        //Mirar si ese jugador existe 
        public async Task<int> GetJugadorDetails(string nombre_Jugador, string contraseña)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.jugador WHERE nombre_Jugador = @nombre_Jugador AND contraseña = @contraseña";

            var resultado = await db.QueryFirstOrDefaultAsync<jugador>(sql, new { nombre_Jugador, contraseña });

            if(resultado != null) return 2;

            sql = @"SELECT * FROM public.jugador WHERE nombre_Jugador = @nombre_Jugador";

            resultado = await db.QueryFirstOrDefaultAsync<jugador>(sql, new { nombre_Jugador });

            if (resultado != null) return 1;

            return 0;
        }
        //Insert<r nuveos jugadores en la BDD

        public async Task<bool> InsertJugador(jugador jugador)
        {
            var db = dbConnection();

            var sql = @"SELECT * FROM public.localizacion WHERE ciudad = @ciudad";

            var resultadoCiudad = await db.QueryFirstOrDefaultAsync<localizacion>(sql, new { jugador.ciudad });

            if (resultadoCiudad == null) return false;

            sql = @" INSERT INTO public.jugador ( nombre_Jugador, contraseña, nivel_Actual, ciudad) VALUES (@nombre_Jugador, @contraseña, @nivel_Actual, @ciudad)";

            var resultado = await db.ExecuteAsync(sql, new { jugador.nombre_Jugador, jugador.contraseña, jugador.nivel_Actual, jugador.ciudad });

            return resultado > 0;
        }
        //Modificar a un jugador
        public async Task<bool> UpdateJugador(string nombre_Jugador, int nivel_Actual)
        {
            var db = dbConnection();

            var sql = @"UPDATE  public.jugador
                        SET nivel_Actual = @nivel_Actual
                        WHERE nombre_Jugador = @nombre_Jugador;
                        ";

            var result = await db.ExecuteAsync(sql, new { nivel_Actual, nombre_Jugador });
            return result > 0;
        }
        //Borrar jugador
        public async Task<bool> DeleteJugador(string jugador)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE FROM public.jugador
                        WHERE nombre_Jugador = @jugador CASCADE
                        ";

            var result = await db.ExecuteAsync(sql, new { jugador });
            return result > 0;
        }
    }
}