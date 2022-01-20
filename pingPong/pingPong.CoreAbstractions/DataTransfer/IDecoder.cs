
namespace pingPong.CoreAbstractions.DataTransfer
{
    public interface IDecoder
    {
        public object Decode(byte[] bytes);
    }
}
