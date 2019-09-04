using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
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
                    DoClient();
                });
                t.Start();
            }
        }

        public void DoClient()
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                // Henter data
                string str = sr.ReadLine();
                // Sender data
                sw.WriteLine(str);
                // Læser data
                str = sr.ReadLine();
                // Sender data
                sw.WriteLine("Count is: " + str);
                // Clear buffer
                sw.Flush();
            }
        }

    }
}
