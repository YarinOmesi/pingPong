
using System.Text.Json;
using pingPong.SocketsAbstractions;

namespace pingPong.Common
{
    public class PersonSocket:IObjectSocket<Person>
    {
        private readonly IObjectSocket<string> _stringSocket;

        public PersonSocket(IObjectSocket<string> stringSocket)
        {
            _stringSocket = stringSocket;
        }

        public Person Receive()
        {
            var json = _stringSocket.Receive();

            return JsonSerializer.Deserialize<Person>(json);
        }

        public void Send(Person value)
        {
            var json = JsonSerializer.Serialize(value);
            _stringSocket.Send(json);
        }
    }
}
