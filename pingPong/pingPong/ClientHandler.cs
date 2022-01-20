using pingPong.CoreAbstractions.Client;
using pingPong.SocketsAbstractions;
using System;

namespace pingPong
{
    public class ClientHandler : IClientHandler<ISocket>
    {
        public void HandleClient(ISocket socket)
        {
            var buffer = new byte[1024];
            int byteRead;
            while((byteRead= socket.Receive(buffer)) > 0)
            {
                var span = new Span<byte>(buffer, 0, byteRead);
                socket.Send(span.ToArray());
            }
        }
    }
}
