using System;
using System.Net;
using GameServer_learn.Application.Handlers;

namespace GameServer_learn
{
    class Program
    {
        static void Main(string[] args)
        {
            var wsServer = new WsGameServer(IPAddress.Any, 8080);
            wsServer.StartServer();
            for (;;)
            {
                var type = Console.ReadLine();
                if (type == "restart")
                {
                    wsServer.RestartServer();
                }

                if (type == "shutdown")
                {
                    wsServer.StopServer();
                    break;
                }
            }
        }
    }
}

