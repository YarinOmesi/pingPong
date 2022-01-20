using pingPong.SocketsAbstractions;
using System.Net.Sockets;

namespace pingPong.SocketImplementation
{
    public class MySocket:ISocket
    {
        private readonly Socket _client;

        public MySocket(Socket client)
        {
            _client = client;
        }

        public int Receive(byte[] buffer)
        {
            return _client.Receive(buffer);
        }

        public void Send(byte[] data)
        {
            _client.Send(data);
        }

        public void Close()
        {
            _client.Close();
        }
    }
}
