
using System.Text;

namespace pingPong.CoreAbstractions.DataTransfer.ConversionsImpl
{
    public class StringConversion:IEncoder,IDecoder
    {

        private readonly Encoding _encoding;

        public StringConversion(Encoding encoding)
        {
            _encoding = encoding;
        }

        public byte[] Encode(object value)
        {
            return _encoding.GetBytes((string)value);
        }

        public object Decode(byte[] bytes)
        {
            return _encoding.GetString(bytes);
        }
    }
}
