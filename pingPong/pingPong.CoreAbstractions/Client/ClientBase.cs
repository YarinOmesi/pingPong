using pingPong.CoreAbstractions.Protocol;
using pingPong.Logger;

namespace pingPong.CoreAbstractions.Client
{
    public abstract class ClientBase<T>
    {
        protected readonly ILogger _logger;
        protected readonly IPacketProtocol _protocol;

        protected ClientBase(IPacketProtocol protocol, string loggerName)
        {
            _protocol = protocol;
            _logger = new Logger.Logger().GetLogger(loggerName);
        }

        public abstract void Run();

    }
}
