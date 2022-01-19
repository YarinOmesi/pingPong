using pingPong.CoreAbstractions.Client;
using System.Net.Sockets;

namespace pingPong.SocketImplementation.Client
{
    public class SocketWriter : IClientWriter<byte[]>
    {
        private readonly Socket _client;

        public SocketWriter(Socket client)
        {
            _client = client;
        }

        public void Write(byte[] value)
        {
            _client.Send(value);
        }
    }
}
