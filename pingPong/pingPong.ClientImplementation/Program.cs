using System;
using System.Net;
using pingPong.Common;
using pingPong.SocketImplementation;

namespace pingPong.ClientImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socketConnector = new SocketConnector();
            var socket = socketConnector.Connect(IPAddress.Parse("127.0.0.1"),int.Parse(args[0]));
            var personSocket = new PersonSocket(socket);
            var client = new PersonClient(personSocket);
            client.Run();
        }
    }
}
