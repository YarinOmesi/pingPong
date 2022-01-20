using pingPong.CoreAbstractions.Listener;
using pingPong.CoreAbstractions.Client;
using System.Net;
using System.Net.Sockets;
using System;
using pingPong.SocketImplementation.Client;
using System.Threading.Tasks;

namespace pingPong.SocketImplementation.Listener
{
    public class SocketListener : IListener
    {
        private readonly int _port;
        private readonly IClientHandlerFactory<byte[], byte[]> _clientHandlerFactory;

        public SocketListener(int port, IClientHandlerFactory<byte[], byte[]> clientHandlerFactory)
        {
            _port = port;
            _clientHandlerFactory = clientHandlerFactory;
        }

        public void StartListening()
        {
            var server = new Socket(SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, _port));

            try
            {
                while (true)
                {
                    var client = server.Accept();
                    Task.Run(() =>
                    {
                        HandleClient(client);
                    });
                }
            }catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }

        }
        private void HandleClient(Socket client)
        {
            var buffer = new byte[1024];
            int bytesRead;
            var handler = _clientHandlerFactory.Create(new SocketWriter(client));
            while ((bytesRead = client.Receive(buffer)) > 0)
            {
                var span = new Span<byte>(buffer, 0, bytesRead);
                handler.HandleClient(span.ToArray());
            }
        }
    }
}
