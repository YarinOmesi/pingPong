using System;
using System.Net;
using System.Text;
using pingPong.Common;
using pingPong.CoreAbstractions.BaseImpl;
using pingPong.Logger;
using pingPong.SocketsAbstractions;

namespace pingPong.ClientImplementation
{
    internal class Client
    {
        private readonly ISocketConnector _socketConnector;
        private readonly ILogger _logger;

        public Client(ISocketConnector socketConnector)
        {
            _socketConnector = socketConnector;
            _logger = new Logger.Logger().GetLogger("Client");
        }

        public void Run(string ip,int port)
        {
            _logger.Debug($"Connecting to {ip}:{port}");
            var socket=_socketConnector.Connect(IPAddress.Parse(ip), port);
            var personSocket = new PersonSocket(new StringSocket(socket, 1024));
            _logger.Debug("Connected");
            while(true)
            {
                Console.WriteLine("Enter name:");
                var name = Console.ReadLine();
                Console.WriteLine("Enter age:");
                var age = int.Parse(Console.ReadLine() ?? "0");

                var person = new Person(name, age);
                personSocket.Send(person);
                var received = personSocket.Receive();
                Console.WriteLine($"Server Replied {received}");
            } 
        }
    }
}
