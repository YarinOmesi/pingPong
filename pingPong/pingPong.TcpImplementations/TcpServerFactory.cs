using pingPong.SocketsAbstractions;
using System.Net;

namespace pingPong.TcpImplementations
{
    public class TcpServerFactory : IServerSocketFactory
    {
        public IServerSocket Create(IPAddress address, int port)
        {
            return new TcpServerSocket(address, port);
        }
    }
}
