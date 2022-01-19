
namespace pingPong.CoreAbstractions.Listener
{
    public interface IClientListenerFactory
    {
        public IClientListener Create(int port);
    }
}
