using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApi.Model
{
    /// <summary>
    /// Clase modelo que representa al objeto de la base de datos ConnectionString sus atributos- Deben coincidir ConnectionString los de la bbdd.
    /// </summary>
    public class localizacion
    {
        public string ciudad { get; set; }
        public double latitud { get; set; }
        public double longitud { get; set; }
    }
}
