using LecturaModel.DAL;
using LecturaModel.DTO;
using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaMedidor.Comunicacion
{
     class HebraCliente
    {

        private ILecturaDAL lecturaDAL = LecturaDALArchivos.GetIntancia();
        private ClienteCom clienteCom;
        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese medidor");
            string medidores = clienteCom.Leer();

            //clienteCom.Escribir("Ingrese Fecha");
            //string fechas = clienteCom.Leer();
            string fechas = DateTime.Now.ToString("dd-MM-yyyy");

            clienteCom.Escribir("Ingrese Lectura en kWh");
            string lecturas = clienteCom.Leer();

            Consumo consumo = new Consumo()
            {
                Medidores = medidores,
                Fecha = fechas,
                Lectura = lecturas+ "kWh"


            };
            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLecturas(consumo);
            }
            clienteCom.Desconectar();

        }

    }
}
