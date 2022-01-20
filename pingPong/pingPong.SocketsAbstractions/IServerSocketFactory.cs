using System.Net;

namespace pingPong.SocketsAbstractions
{
    public interface IServerSocketFactory
    {
        public IServerSocket Create(IPAddress address, int port);/
    }
}
