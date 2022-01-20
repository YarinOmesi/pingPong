using System;
using System.Net;
using System.Text;
using pingPong.SocketsAbstractions;

namespace pingPong.ClientImplementation
{
    internal class Client
    {
        private readonly ISocketConnector _socketConnector;

        public Client(ISocketConnector socketConnector)
        {
            _socketConnector = socketConnector;
        }

        public void Run(string ip,int port)
        {
            var socket=_socketConnector.Connect(IPAddress.Parse(ip), port);
            string msg;
            do
            {
                Console.WriteLine("Enter Message:");
                msg = Console.ReadLine();

                socket.Send(Encoding.UTF8.GetBytes(msg));
                var buffer = new byte[1024]  ;
                var bytesRead = socket.Receive(buffer);
                var asString = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Server Replied {asString}");
            } while (msg != "stop");
        }
    }
}
