using pingPong.SocketsAbstractions;
using pingPong.Common;
using pingPong.CoreAbstractions.Listener;
using pingPong.Logger;

namespace pingPong.ClientHandlers.PersonHandlers
{
    public class PersonClientHandler : IClientHandler
    {
        private readonly IObjectSocket<Person> _socket;
        private readonly ILogger _logger;

        public PersonClientHandler(IObjectSocket<Person> socket)
        {
            _socket = socket;
            _logger=new Logger.Logger().GetLogger("PersonClientHandler");
        }

        public void HandleClient()
        {
            Person? value;
            while((value = _socket.Receive())!=null)
            {
                _logger.Debug($"recv: [{value}]");
                _socket.Send(value);
            }
        }
    }
}
