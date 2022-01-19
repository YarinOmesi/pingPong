
namespace pingPong.CoreAbstractions.Client
{
    internal interface IClientWriter<T>
    {
        void Write(T value);
    }
}
