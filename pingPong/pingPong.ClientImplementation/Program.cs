using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using pingPong.CoreAbstractions.DataTransfer;
using pingPong.CoreAbstractions.DataTransfer.ConversionsImpl;
using pingPong.CoreAbstractions.Protocol;
using pingPong.SocketImplementation;

namespace pingPong.ClientImplementation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var socketConnector = new SocketConnector();
            var socket = socketConnector.Connect(IPAddress.Parse("127.0.0.1"),int.Parse(args[0]));

            var personConversion = new ObjectConversionBase(new BinaryFormatter());
            var encoders = new Dictionary<Type, IEncoder>
            {
                {typeof(Person),personConversion}
            };
            var decoders = new Dictionary<Type, IDecoder>
            {
                {typeof(Person),personConversion}
            };
            var conversion = new Conversions(encoders, decoders);
            var protocol = new ProtocolBase(conversion,socket);
            var client = new PersonClient(protocol);
            client.Run();
        }
    }
}
