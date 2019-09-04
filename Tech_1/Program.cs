using System;
using System.IO;
using System.Net.Sockets;

namespace Tech_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.Start();

            Console.ReadLine();
        }

        
    }
}
