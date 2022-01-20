using pingPong.SocketsAbstractions;
using System;
using pingPong.Common;
using pingPong.CoreAbstractions.Listener;

namespace pingPong
{
    public class ClientHandler : IClientHandler
    {
        private readonly IObjectSocket<Person> _socket;

        public ClientHandler(IObjectSocket<Person> socket)
        {
            _socket = socket;
        }

        public void HandleClient()
        {
            Person? value;
            while((value = _socket.Receive())!=null)
            {
                _socket.Send(value);
            }
        }
    }
}
