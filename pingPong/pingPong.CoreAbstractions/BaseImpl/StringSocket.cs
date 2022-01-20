using System.Text;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class StringSocket:IObjectSocket<string>
    {
        private readonly byte[] _buffer;
        private readonly Encoding _encoding;

        public StringSocket(int bufferSize,Encoding encoding)
        {
            _encoding = encoding;
            _buffer = new byte[bufferSize];
        }
        public StringSocket(int bufferSize):this(bufferSize,Encoding.UTF8)
        {
        }

        public string Receive(ISocket socket)
        {
            var bytesRead=socket.Receive(_buffer);
            return _encoding.GetString(_buffer, 0, bytesRead);
        }

        public void Send(ISocket socket, string value)
        {
            var asBytes = _encoding.GetBytes(value);
            socket.Send(asBytes);
        }
    }
}
