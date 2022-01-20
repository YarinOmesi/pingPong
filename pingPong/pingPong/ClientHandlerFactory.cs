using pingPong.Common;
using pingPong.SocketsAbstractions;
using pingPong.CoreAbstractions.BaseImpl;
using pingPong.CoreAbstractions.Listener;

namespace pingPong
{
    internal class ClientHandlerFactory : IClientHandlerFactory
    {
        private const int STRING_BUFFER_SIZE = 1024;
        public IClientHandler Create(ISocket socket)
        {
            //var stringSocket = new StringSocket(socket, STRING_BUFFER_SIZE);
            var personSocket = new PersonSocket(socket);
            return new ClientHandler(personSocket);
        }
    }
}
