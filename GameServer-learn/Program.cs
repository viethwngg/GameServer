using System;
using System.Net;
using GameServer_learn.Application.Handlers;
using GameServer_learn.Application.Interface;

namespace GameServer_learn
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayerManager playerManager = new PlayersManager();
            var wsServer = new WsGameServer(IPAddress.Any, 8080, playerManager);
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

