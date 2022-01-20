using System.Net;

namespace pingPong.SocketsAbstractions
{
    public interface ISocketFactory
    {
        public ISocket Create(IPAddress addr, int port);
    }
}
