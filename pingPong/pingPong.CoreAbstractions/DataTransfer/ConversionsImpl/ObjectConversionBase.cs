using System.IO;
using System.Runtime.Serialization;

namespace pingPong.CoreAbstractions.DataTransfer.ConversionsImpl
{
    public class ObjectConversionBase:IEncoder,IDecoder
    {
        private readonly IFormatter _formatter;

        public ObjectConversionBase(IFormatter formatter)
        {
            _formatter = formatter;
        }

        public byte[] Encode(object value)
        {
            var memoryBuffer = new MemoryStream();
            _formatter.Serialize(memoryBuffer,value);
            return memoryBuffer.ToArray();
        }

        public object Decode(byte[] bytes)
        {
            return _formatter.Deserialize(new MemoryStream(bytes));
        }
    }
}
