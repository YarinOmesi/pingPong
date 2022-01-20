using System;
using System.Net;
using System.Text;
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
            _logger.Debug("Connected");
            string msg;
            do
            {
                Console.WriteLine("Enter Message:");
                msg = Console.ReadLine();

                socket.Send(Encoding.UTF8.GetBytes(msg));
                var buffer = new byte[1024]  ;
                var bytesRead = socket.Receive(buffer);
                var asString = Encoding.UTF8.GetString(buffer,0,bytesRead);
                Console.WriteLine($"Server Replied {asString}");
            } while (msg != "stop");
            _logger.Debug("Ended");
        }
    }
}
