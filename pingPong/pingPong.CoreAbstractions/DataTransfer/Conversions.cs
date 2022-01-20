using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pingPong.CoreAbstractions.Exceptions;
using pingPong.Logger;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.DataTransfer
{
    public class Conversions
    {
        private readonly IDictionary<Type, IEncoder> _encoders;
        private readonly IDictionary<Type, IDecoder> _decoders;
        private readonly ILogger _logger;

        public Conversions(IDictionary<Type, IEncoder> encoders, IDictionary<Type, IDecoder> decoders)
        {
            _encoders = encoders;
            _decoders = decoders;
            _logger = new Logger.Logger().GetLogger("Conversions");
        }


        public T Decoded<T>(byte[] bytes)
        {
            var type = typeof(T);

            if (!_decoders.ContainsKey(type))
            {
                throw new NotFoundException($"Decoder not found in dictionary,type:{type}");
            }

            var obj = _decoders[type].Decode(bytes);
            try
            {
                return (T)obj;
            }
            catch (InvalidCastException e)
            {
                _logger.Error("Casting Error", e);
                return default;
            }
        }

        public byte[] Encoded<T>(T value)
        {
            var type = typeof(T);
            if (!_encoders.ContainsKey(type))
            {
                throw new NotFoundException($"Encoder not found in dictionary,type:{type}");
            }

            return  _encoders[type].Encode(value);
        }
    }
}
