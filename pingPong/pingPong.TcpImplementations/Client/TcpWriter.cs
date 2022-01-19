using pingPong.CoreAbstractions.Client;
using System.Net.Sockets;

namespace pingPong.TcpImplementations.Client
{
    public class TcpWriter : IClientWriter<byte[]>
    {
        private readonly TcpClient _client;

        public TcpWriter(TcpClient client)
        {
            _client = client;
        }

        public void Write(byte[] value)
        {
            _client.GetStream().Write(value, 0, value.Length);
        }
    }
}
