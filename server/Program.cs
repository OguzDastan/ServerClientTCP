using System;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();

            server.Start();

            Console.ReadLine();
        }
    }
}
