using System;
using System.Net;
using System.Text;
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
            var stringSocket = new StringSocket(socket, 1024);
            _logger.Debug("Connected");
            string msg;
            do
            {
                Console.WriteLine("Enter Message:");
                msg = Console.ReadLine();

                stringSocket.Send(msg);
                var received = stringSocket.Receive();
                Console.WriteLine($"Server Replied {received}");
            } while (msg != "stop");
            _logger.Debug("Ended");
        }
    }
}
