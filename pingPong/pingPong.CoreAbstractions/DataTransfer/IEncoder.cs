namespace pingPong.CoreAbstractions.DataTransfer
{
    public interface IEncoder
    {
        public byte[] Encode(object value);
    }
}
