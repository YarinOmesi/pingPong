using System;
using pingPong.CoreAbstractions.Client;
using pingPong.CoreAbstractions.Protocol;

namespace pingPong.ClientImplementation
{
    internal class PersonClient : ClientBase<Person>
    {

        public PersonClient(IPacketProtocol protocol) : base(protocol, "PersonClient")
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
                _protocol.Send(person);

                var recved = _protocol.Receive<Person>();
                _logger.Info($"Received {recved}");
            }
        }

    }
}
