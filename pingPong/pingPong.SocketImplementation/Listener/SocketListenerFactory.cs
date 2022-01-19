using pingPong.CoreAbstractions.Listener;

namespace pingPong.SocketImplementation.Listener
{
    public class SocketListenerFactory : IClientListenerFactory
    {
        public IClientListener Create(int port)
        {
            return new SocketListener(port,);
        }
    }
}
