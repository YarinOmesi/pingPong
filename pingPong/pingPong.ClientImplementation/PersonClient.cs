
using pingPong.Common;
using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;

namespace pingPong.ClientImplementation
{
    internal class PersonClient:ClientBase<Person>
    {
        public PersonClient(IObjectSocket<Person> socket)
            : base(socket, "PersonClient")
        {
        }

        public override void Run()
        {
            Person? person;
            while ((person = _socket.Receive())!=null)
            {
                _logger.Debug($"Recved {person}");
                _socket.Send(person);
            }
        }
    }
}
