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

            var conversionCreator = new PersonClientConversionCreator();
            var protocol = new ProtocolBase(conversionCreator.Create(),socket);
            var client = new PersonClient(protocol);
            client.Run();
        }
    }
}
