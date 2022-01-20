
namespace pingPong.SocketsAbstractions
{
    public interface IObjectSocket<T>
    {
        public T Receive(ISocket socket);

        public void Send(ISocket socket, T value);
    }
}
