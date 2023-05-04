using Dapper;
using Npgsql;
using TodoApi.Model;
using TodoApi.Models;

namespace TodoApi.Data.Repositories
{
    /// <summary>
    /// Clase Car que contiene todos los métodos SQL querys
    /// </summary>
    public class localizacionRepository
    {
        private PosgreSQLConfig connexionString;
        public localizacionRepository(PosgreSQLConfig connectionString)
        {
            this.connexionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(connexionString.ConnectionString);
        }

        public async Task<IEnumerable<localizacion>> GetAllCars()
        {
            var db = dbConnection();

            var sql = @"SELECT  * FROM public.localizacion";

            return await db.QueryAsync<localizacion>(sql, new { });

        }

        public async Task<localizacion> GetCarDetails(int id)
        {
            var db = dbConnection();

            //var sql = @"SELECT ciudad, longitud, latitud FROM public.localizacion WHERE ciudad = @Id";
            var sql = @"SELECT ciudad, longitud, latitud FROM public.localizacion WHERE ciudad = @ciudad";

            return await db.QueryFirstOrDefaultAsync<localizacion>(sql, new { Id = id });
        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO public.cars ( make, model, color, year, doors ) VALUES (@Make, @Model, @Color, @Year, @Doors)";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors });
            return result > 0;
        }

        public async Task<bool> UpdateCar(Car car)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE  public.cars
                        SET make = @Make,
                            model  =  @Model,
                            color = Ccolor,
                            year = @Year,
                            doors = @Doors,
                        WHERE id = @Id;
                        ";

            var result = await db.ExecuteAsync(sql, new { car.Make, car.Model, car.Color, car.Year, car.Doors, car.Id });
            return result > 0;
        }

        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE FROM public.cars
                        WHERE id = @Id
                            
                        ";

            var result = await db.ExecuteAsync(sql, new { Id = car.Id });
            return result > 0;
        }


    }
}