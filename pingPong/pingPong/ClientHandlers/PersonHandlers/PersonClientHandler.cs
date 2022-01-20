using System;
using pingPong.ClientImplementation;
using pingPong.CoreAbstractions.Listener;
using pingPong.CoreAbstractions.Protocol;
using pingPong.Logger;

namespace pingPong.ClientHandlers.PersonHandlers
{
    public class PersonClientHandler : IClientHandler
    {
        private readonly IPacketProtocol _protocol;
        private readonly ILogger _logger;

        public PersonClientHandler(IPacketProtocol protocol)
        {
            _protocol = protocol;
            _logger=new Logger.Logger().GetLogger("PersonClientHandler");
        }

        public void HandleClient()
        {
            try
            {
                while (true)
                {
                    var receivedPerson = _protocol.Receive<Person>();
                    _logger.Info($"Received {receivedPerson}");
                    _protocol.Send(receivedPerson);
                }
            }
            catch (Exception e)
            {
                _logger.Error("Error", e);
            }
            finally
            {
                _protocol.Close();
            }
        }
    }
}
