using pingPong.Logger;
using pingPong.SocketsAbstractions;

namespace pingPong.CoreAbstractions.Client
{
    public abstract class ClientBase<T>
    {
        protected readonly ILogger _logger;
        protected readonly IObjectSocket<T> _socket;

        protected ClientBase( IObjectSocket<T> socket)
        {
            _socket = socket;
            _logger = new Logger.Logger().GetLogger("Client");
        }

        public abstract void Run();

    }
}
