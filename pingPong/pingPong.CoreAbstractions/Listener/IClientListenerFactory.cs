
namespace pingPong.CoreAbstractions.Listener
{
    internal interface IClientListenerFactory
    {
        IClientListener Create(int port);
    }
}
