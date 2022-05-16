using LecturaModel.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturaModel.DAL
{
    public class LecturaDALArchivos : ILecturaDAL
    {
        private LecturaDALArchivos()
        {

        }


        private static LecturaDALArchivos instancia;

        public static LecturaDALArchivos GetIntancia()
        {
            if (instancia == null)
            {
                instancia = new LecturaDALArchivos();
            }
            return instancia;
        }




        private static string url = Directory.GetCurrentDirectory();

        private static string archivo = url + "/lectura.txt";

        public void AgregarLecturas(Consumo consumo)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, true))
                {
                    writer.WriteLine(consumo.Medidores + ";" + consumo.Fecha + ";" + consumo.Lectura);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Consumo> ObtenerLecturas()
        {
            List<Consumo> lista = new List<Consumo>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split(';');
                            Consumo consumo = new Consumo()
                            {
                                Medidores = arr[0],
                                Fecha = arr[1],
                                Lectura = arr[2]
                            };
                            lista.Add(consumo);
                        }
                    } while (texto != null);
                }
            }
            catch (Exception ex)
            {
                lista = null;
            }
            return lista;
        }


    }
}
