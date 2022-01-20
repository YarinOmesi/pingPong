using pingPong.CoreAbstractions.Listener;
using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;
using System;
using System.Net;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class ListenerBase : IListener
    {
        private readonly int _port;
        private readonly IClientHandlerFactory<ISocket, byte[]> _clientHandlerFactory;
        private readonly IServerSocketFactory _serverSocketFactory;

        public ListenerBase(int port, IClientHandlerFactory<ISocket, byte[]> clientHandlerFactory, IServerSocketFactory serverSocketFactory)
        {
            _port = port;
            _clientHandlerFactory = clientHandlerFactory;
            _serverSocketFactory = serverSocketFactory;
        }

        public void StartListening()
        {
            var server = _serverSocketFactory.Create(IPAddress.Any,_port);
            try
            {
                server.Start();
                while (true)
                {
                    var client=server.AcceptClient();
                    var handler = _clientHandlerFactory.Create(new SocketWriter(client));
                    handler.HandleClient(client);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error {e.Message}");
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
