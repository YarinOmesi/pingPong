using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pingPong
{
    internal class ClientHandlerFactory : IClientHandlerFactory<ISocket, byte[]>
    {
        public IClientHandler<ISocket> Create(IClientWriter<byte[]> writer)
        {
            return new ClientHandler();
        }
    }
}
