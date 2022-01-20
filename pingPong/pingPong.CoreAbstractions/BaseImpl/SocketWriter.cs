using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class SocketWriter : IClientWriter<byte[]>
    {
        private readonly ISocket _client;

        public SocketWriter(ISocket client)
        {
            _client = client;
        }

        public void Write(byte[] value)
        {
            _client.Send(value);
        }
    }
}
