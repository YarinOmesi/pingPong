using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using pingPong.CoreAbstractions.DataTransfer;
using pingPong.CoreAbstractions.DataTransfer.ConversionsImpl;

namespace pingPong.ClientImplementation
{
    public class PersonClientConversionCreator
    {
        public Conversions Create()
        {
            var personConversion = new ObjectConversionBase(new BinaryFormatter());
            var encoders = new Dictionary<Type, IEncoder>
            {
                {typeof(Person),personConversion}
            };
            var decoders = new Dictionary<Type, IDecoder>
            {
                {typeof(Person),personConversion}
            };
            return new Conversions(encoders, decoders);
        }
    }
}
