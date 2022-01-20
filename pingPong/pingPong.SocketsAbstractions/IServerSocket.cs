
namespace pingPong.SocketsAbstractions
{
    public interface IServerSocket
    {
        public ISocket AcceptClient();

        public void Start();

        public void Stop();
    }
}
