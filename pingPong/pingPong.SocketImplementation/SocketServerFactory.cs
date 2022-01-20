using pingPong.SocketsAbstractions;
using System.Net;

namespace pingPong.SocketImplementation
{
    public class SocketServerFactory : IServerSocketFactory
    {
        public IServerSocket Create(IPAddress address, int port)
        {
            return new SocketServer(address, port);
        }
    }
}
