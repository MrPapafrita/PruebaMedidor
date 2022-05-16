using LecturaModel.DAL;
using LecturaModel.DTO;
using PruebaMedidor.Comunicacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaMedidor
{
    class Program
    {
        private static ILecturaDAL lecturaDAL = LecturaDALArchivos.GetIntancia();
        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("¿Que quiere hacer?");
            Console.WriteLine(" 1. Ingresar Lectura \n 2. Mostrar Lecturas \n 0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    Ingresar();
                    break;
                case "2":
                    Mostrar();
                    break;
                case "0":
                    Desconectar();
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Ingrese de nuevo");
                    break;
            }
            return continuar;
        }
        static void Main(string[] args)
        { 
            HebraServidor hebra = new HebraServidor();
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.Start();
            bool continuar = true;
            do
            {
                 continuar = Menu();
            }while (continuar==true);
        }

        static void Ingresar()
        {
            Console.WriteLine("Ingrese Medidor: ");
            string medidores = Console.ReadLine().Trim();
            string fecha = DateTime.Now.ToString("dd-MM-yyyy");
            Console.WriteLine("Ingrese Lectura :");
            string lectura = Console.ReadLine().Trim();
            Consumo consumo = new Consumo()
            {
                Medidores = medidores,
                Fecha = fecha,
                Lectura = lectura + "kWh"
            };
            lock (lecturaDAL)
            {
                lecturaDAL.AgregarLecturas(consumo);
            }

        }

        static void Mostrar()
        {
            List<Consumo> consumos = null;
            lock (lecturaDAL)
            {
                consumos = lecturaDAL.ObtenerLecturas();
            }
            foreach (Consumo consumo in consumos)
            {
                Console.WriteLine(consumo);
            }
        }

        public static void Desconectar() {
            System.Environment.Exit(0);
        }
    }
}
