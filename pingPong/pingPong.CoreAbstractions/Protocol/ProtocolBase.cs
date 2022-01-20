using System;
using pingPong.CoreAbstractions.DataTransfer;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.Protocol
{
    public class ProtocolBase:IPacketProtocol
    {
        private readonly Conversions _conversions;
        private readonly ISocket _socket;

        public ProtocolBase(Conversions conversions, ISocket socket)
        {
            _conversions = conversions;
            _socket = socket;
        }

        public T Receive<T>()
        {
            // read length
            const int bufferSize = sizeof(int);
            var lengthBuffer = new byte[bufferSize];
            _socket.Receive(lengthBuffer);
            // read data
            var dataLength = BitConverter.ToInt32(lengthBuffer);
            var dataBuffer = new byte[dataLength];
            _socket.Receive(dataBuffer);
            // convert
            return _conversions.Decoded<T>(dataBuffer);
        }

        public void Send<T>(T value)
        {
            var bytes =_conversions.Encoded(value);
            var sizeAsBytes = BitConverter.GetBytes(bytes.Length);
            _socket.Send(sizeAsBytes);
            _socket.Send(bytes);
        }

        public void Close()
        {
           _socket.Close();
        }
    }
}
