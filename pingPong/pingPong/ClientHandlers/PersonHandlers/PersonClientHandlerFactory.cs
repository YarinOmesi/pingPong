using pingPong.Common;
using pingPong.SocketsAbstractions;
using pingPong.CoreAbstractions.BaseImpl;
using pingPong.CoreAbstractions.Listener;

namespace pingPong.ClientHandlers.PersonHandlers
{
    internal class PersonClientHandlerFactory : IClientHandlerFactory
    {
        public IClientHandler Create(ISocket socket)
        {
            var personSocket = new PersonSocket(socket);
            return new PersonClientHandler(personSocket);
        }
    }
}
