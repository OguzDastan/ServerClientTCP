using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
namespace server
{
    class Server
    {
        public TcpClient socket;
        public Server()
        {

        }
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 7);
            server.Start();

            while (true)
            {
                socket = server.AcceptTcpClient();

                Task t = new Task(() =>
                {
                    TcpClient TempSocket = socket;
                    Thread.Sleep(5000);
                    DoClient(TempSocket);
                });
                t.Start();
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                Console.WriteLine("Server 1.0");
                // Henter data
                string str = sr.ReadLine();
                // Sender data
                sw.WriteLine(str);

                // Læser data
                str = sr.ReadLine();
                // Sender data
                sw.WriteLine("Count is: " + str);

                // henter data
                str = sr.ReadLine();
                // sender data
                sw.WriteLine(str);

                // Clear buffer
                sw.Flush();
            }
        }

    }
}
