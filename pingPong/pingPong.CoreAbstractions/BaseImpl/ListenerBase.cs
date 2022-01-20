using pingPong.CoreAbstractions.Listener;
using pingPong.SocketsAbstractions;
using System;
using System.Threading.Tasks;
using pingPong.Logger;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class ListenerBase : IListener
    {
        private readonly IServerSocket _server;
        private readonly IClientHandlerFactory _clientHandlerFactory;
        private readonly ILogger _logger;

        public ListenerBase(IServerSocket server, IClientHandlerFactory clientHandlerFactory)
        {
            _server = server;
            _clientHandlerFactory = clientHandlerFactory;
            _logger = new Logger.Logger().GetLogger("BaseListener");
        }

        public void StartListening()
        {
            try
            {
                _server.Start();
                while (true)
                {
                    _logger.Debug("Waiting For Client...");
                    var client=_server.AcceptClient();
                    _logger.Debug("Client Connected");
                    var handler = _clientHandlerFactory.Create(client);
                    Task.Run(() =>
                    {
                        handler.HandleClient();
                    });
                }
            }
            catch(Exception e)
            {
                _logger.Error("Error",e);
            }
            finally
            {
                _server.Stop();
            }
        }
    }
}
