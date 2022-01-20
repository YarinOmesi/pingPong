using System.Net;
using pingPong.ClientHandlers.PersonHandlers;
using pingPong.CoreAbstractions.BaseImpl;
using pingPong.SocketImplementation;

namespace pingPong
{
    internal class Bootstrapper
    {
        public void Bootstrapp(string [] args)
        {
            if (args.Length == 1 && int.TryParse(args[0], out var port))
            {
                var handlerFactory = new PersonClientHandlerFactory();
                var server = new SocketServer(IPAddress.Any, port);
                var listener = new ListenerBase(server, handlerFactory);
                listener.StartListening();
            }
            else
            {
                System.Console.WriteLine("Usage: program.exe <port>");
            }
        }
    }
}
