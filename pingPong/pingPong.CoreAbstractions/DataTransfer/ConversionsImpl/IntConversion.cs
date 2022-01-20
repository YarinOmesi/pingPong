
using System;

namespace pingPong.CoreAbstractions.DataTransfer.ConversionsImpl
{
    public class IntConversion:IEncoder,IDecoder
    {
        public byte[] Encode(object value)
        {
            return BitConverter.GetBytes((int) value);
        }

        public object Decode(byte[] bytes)
        {
            return BitConverter.ToInt32(bytes);
        }
    }
}
