
namespace pingPong.CoreAbstractions.Protocol
{
    public interface IPacketProtocol
    {
        public T Receive<T>();

        public void Send<T>(T value);

        public void Close();
    }
}
