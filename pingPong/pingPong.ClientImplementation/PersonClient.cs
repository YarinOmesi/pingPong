using System;
using pingPong.Common;
using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;

namespace pingPong.ClientImplementation
{
    internal class PersonClient : ClientBase<Person>
    {
        public PersonClient(IObjectSocket<Person> socket)
            : base(socket, "PersonClient")
        {
        }

        public override void Run()
        {
            while (true)
            {
                Console.WriteLine("Enter name");
                var name = Console.ReadLine();
                Console.WriteLine("Enter age");
                var age = int.Parse(Console.ReadLine() ?? "0");
                var person = new Person(name, age);
                _socket.Send(person);

                var recved = _socket.Receive();
                _logger.Info($"Received {recved}");
            }
        }
    }
}
