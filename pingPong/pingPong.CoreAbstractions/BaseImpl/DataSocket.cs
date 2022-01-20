using System;
using pingPong.Logger;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class DataSocket:IObjectSocket<byte[]>
    {
        private const int LENGTH_BYTES = 4;
        private readonly ISocket _client;
        private readonly ILogger _logger;

        public DataSocket(ISocket client)
        {
            _client = client;
            _logger = new Logger.Logger().GetLogger("DataSocket");
        }

        public byte[] Receive()
        {

            var lengthBytes = new byte[LENGTH_BYTES];
            _client.Receive(lengthBytes);
            var length = BitConverter.ToInt32(lengthBytes, 0);
            _logger.Debug($"Packet Size: {lengthBytes}");
            var dataBytes = new byte[length];
            var bytesRead = _client.Receive(dataBytes);
            // TODO: may be throw an error
            _logger.Debug($"Received Packet Size: {bytesRead}");
            return dataBytes;
        }

        public void Send(byte[] data)
        {
            var lengthBytes = BitConverter.GetBytes(data.Length);
            _client.Send(lengthBytes);
            _client.Send(data);
        }
    }
}
