using pingPong.CoreAbstractions.Listener;
using pingPong.SocketsAbstractions;
using System;
using System.Net;
using System.Threading.Tasks;
using pingPong.Logger;

namespace pingPong.CoreAbstractions.BaseImpl
{
    public class ListenerBase : IListener
    {
        private readonly int _port;
        private readonly IClientHandlerFactory _clientHandlerFactory;
        private readonly IServerSocketFactory _serverSocketFactory;
        private readonly ILogger _logger;

        public ListenerBase(int port, IClientHandlerFactory clientHandlerFactory, IServerSocketFactory serverSocketFactory)
        {
            _port = port;
            _clientHandlerFactory = clientHandlerFactory;
            _serverSocketFactory = serverSocketFactory;
            _logger = new Logger.Logger().GetLogger("BaseListener");
        }

        public void StartListening()
        {
            var server = _serverSocketFactory.Create(IPAddress.Any,_port);
            try
            {
                server.Start();
                while (true)
                {
                    _logger.Debug("Waiting For Client...");
                    var client=server.AcceptClient();
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
                server.Stop();
            }
        }
    }
}
