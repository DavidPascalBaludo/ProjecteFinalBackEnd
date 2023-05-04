using System;
using System.Collections.Generic;
using System.Text;
namespace TodoApi.Models
{

    public class PosgreSQLConfig : DbContext
    {

        protected readonly IConfiguration Configuration;
        public string ConnectionString;

        /// <summary>
        /// M�todo que lee la configuracion de coneccion a nuestra bd del fichero appsettings
        /// </summary>
        /// <param name="configuration"></param>
        public PosgreSQLConfig(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("WebApiDatabase");
        }



        //public DbSet<Car> car { get; set; } //NO NECESARIO
    }
}
