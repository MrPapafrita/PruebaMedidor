using ServidorSocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PruebaMedidor.Comunicacion
{
   class HebraServidor
    {


        public void Ejecutar()
        {
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            ServerSocket serverSocket = new ServerSocket(puerto);
            Console.WriteLine("Inciando server en puerto {0}", puerto);

            if (serverSocket.Iniciar())
            {
                while (true)
                {
                    Console.WriteLine("esperando cliente.....");

                    Socket cliente = serverSocket.ObtenerCliente();

                    Console.WriteLine("Cliente recibido");

                    ClienteCom clienteCom = new ClienteCom(cliente);
                    HebraCliente clienteThread = new HebraCliente(clienteCom);

                    Thread t = new Thread(new ThreadStart(clienteThread.Ejecutar));

                    t.IsBackground = true;
                    t.Start();



                }


            }

        }



    }
}
