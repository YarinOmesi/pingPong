using pingPong.SocketsAbstractions;
using System.Net;
using System.Net.Sockets;

namespace pingPong.SocketImplementation
{
    public class SocketServer : IServerSocket
    {
        private readonly Socket _server;
        private readonly IPAddress _addr;
        private readonly int _port;

        public SocketServer(IPAddress addr, int port)
        {
            _addr = addr;
            _port = port;
        }

        public ISocket AcceptClient()
        {
            var client = _server.Accept();
            return new MySocket(client);
        }

        public void Start()
        {
            _server.Bind(new IPEndPoint(_addr, _port));
            _server.Listen();
        }

        public void Stop()
        {
            _server.Close();
        }
    }
}
