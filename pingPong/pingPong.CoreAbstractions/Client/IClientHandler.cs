
namespace pingPong.CoreAbstractions.Client
{
    internal interface IClientHandler<T>
    {
        public void HandleClient(T value);
    }
}
