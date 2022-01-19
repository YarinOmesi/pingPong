using pingPong.CoreAbstractions.Client;
using pingPong.CoreAbstractions.Listener;
using pingPong.TcpImplementations.Client;
using System;
using System.Net;
using System.Net.Sockets;

namespace pingPong.TcpImplementations.Listener
{
    public class TcpClientListener : IClientListener
    {
        private readonly int _port;
        private readonly IClientHandlerFactory<byte[], byte[]> _clientHandlerFactory;

        public TcpClientListener(int port, IClientHandlerFactory<byte[], byte[]> clientHandlerFactory)
        {
            _port = port;
            _clientHandlerFactory = clientHandlerFactory;
        }


        public void StartListening()
        {
            var server = new TcpListener(IPAddress.Any,_port);
            server.Start();
            try
            {
                while (true)
                {
                    var client = server.AcceptTcpClient();
                    HandleClient(client);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally
            {
                server.Stop();
            }
            
        }
        private void HandleClient(TcpClient client)
        {
            var handler = _clientHandlerFactory.Create(new TcpWriter(client));
            var stream = client.GetStream();
            var buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = stream.Read(buffer)) > 0)
            {
                var span = new Span<byte>(buffer, 0, bytesRead);
                handler.HandleClient(span.ToArray());
            }
        }
    }
}
