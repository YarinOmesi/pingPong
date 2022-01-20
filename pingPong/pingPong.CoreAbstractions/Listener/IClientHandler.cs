
namespace pingPong.CoreAbstractions.Client
{
    public interface IClientHandler<T>
    {
        public void HandleClient(T value);
    }
}
