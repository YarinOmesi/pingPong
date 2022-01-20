
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using pingPong.Logger;
using pingPong.SocketsAbstractions;

namespace pingPong.Common
{
    public class PersonSocket:IObjectSocket<Person>
    {
        private readonly ISocket _socket;
        private readonly ILogger _logger;
        private readonly BinaryFormatter _formatter;
        public PersonSocket(ISocket socket)
        {
            _socket = socket;
            _formatter = new BinaryFormatter();
            _logger = new Logger.Logger().GetLogger("PersonSocket");
        }

        public Person Receive()
        {
            var buffer = new byte[512];
            var memoryStream = new MemoryStream(buffer);
            var byteRead = _socket.Receive(buffer);
            return _formatter.Deserialize(memoryStream) as Person;
        }

        public void Send(Person value)
        {
            var memoryStream = new MemoryStream();
            _formatter.Serialize(memoryStream, value);
            _socket.Send(memoryStream.ToArray());
        }
    }
}
