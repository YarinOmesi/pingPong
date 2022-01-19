
namespace pingPong.CoreAbstractions.Listener
{
    public interface IClientListenerFactory
    {
        IClientListener Create(int port);
    }
}
