using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaModel.DTO
{
    public class Consumo
    {

        private string medidores;
        private string fecha;
        private string lectura;

        public string Medidores { get => medidores; set => medidores = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Lectura { get => lectura; set => lectura = value; }

        public override string ToString()
        {
            return medidores + " " + fecha + " " + lectura;
        }
    }
}
