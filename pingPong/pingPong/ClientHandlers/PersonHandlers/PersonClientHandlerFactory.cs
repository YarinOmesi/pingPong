using pingPong.SocketsAbstractions;
using pingPong.CoreAbstractions.DataTransfer;
using pingPong.CoreAbstractions.Listener;
using pingPong.CoreAbstractions.Protocol;

namespace pingPong.ClientHandlers.PersonHandlers
{
    internal class PersonClientHandlerFactory : IClientHandlerFactory
    {
        private readonly Conversions _conversions;
        public PersonClientHandlerFactory(Conversions conversions)
        {
            _conversions = conversions;
        }

        public IClientHandler Create(ISocket socket)
        {
            var protocol = new ProtocolBase(_conversions, socket);
            return new PersonClientHandler(protocol);
        }
    }
}
