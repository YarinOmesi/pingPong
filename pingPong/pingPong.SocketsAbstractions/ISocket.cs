
namespace pingPong.SocketsAbstractions
{
    public interface ISocket
    {
        public int Recv(byte[] buffer);

        public void Send(byte[] data);
    }
}
