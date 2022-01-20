
namespace pingPong.CoreAbstractions.Client
{
    public interface IClientWriter<T>
    {
        void Write(T value);
    }
}
