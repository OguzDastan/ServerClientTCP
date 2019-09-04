using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.Sockets;

namespace Tech_1
{
    internal class Worker
    {
        public Worker()
        {

        }
        public void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", 7))
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                string str = "Den Besked jeg sender";
                sw.WriteLine(str);
                sw.WriteLine(str.Length);
                sw.Flush();

                string strin = sr.ReadLine();
                Console.WriteLine(strin);
                strin = sr.ReadLine();
                Console.WriteLine(strin);
            }
        }
    }
}
