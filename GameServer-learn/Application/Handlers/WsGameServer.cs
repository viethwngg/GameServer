using System.Net;
using System.Net.Sockets;
using GameServer_learn.Application.Interface;
using NetCoreServer;

namespace GameServer_learn.Application.Handlers;

public class WsGameServer: WsServer, IWsGameServer
{
    private readonly int _port;
    // private readonly IGameLogger _logger;
    public readonly IPlayerManager PlayerManager;
    public WsGameServer(IPAddress address, int port, IPlayerManager playerManager) : base(address, port)
    {
        _port = port;
        PlayerManager = playerManager;
        //_logger = _logger;
    }

    protected override TcpSession CreateSession() //user connect vào cổng --> tạo session kết nối
    {
        //todo handle new session 
        Console.WriteLine("New Session connected");
        return base.CreateSession();
    }
    
    
    
    public void SendAll(string mes)
    {
        this.MulticastText(mes);
    }
    
    public WsGameServer(IPEndPoint endpoint, int port, IPlayerManager playerManager) : base(endpoint)
    {
        _port = port;
        PlayerManager = playerManager;
    }

    public void StartServer()
    {
        //todo logic before start server
        if (this.Start())
        {
            Console.WriteLine($"Server started at {_port}");
            return;
        }
    }

    protected override void OnError(SocketError error)
    {
        Console.WriteLine($"Server Error: {error}");
        base.OnError(error);
    }
    
    public void StopServer()
    {
        //todo logic before stop server
        this.Stop();
    }

    public void RestartServer()
    {
        //todo logic before restart server
        // if (this.Restart())
        // {
        //     _logger.Print("Server restarted");
        // }
        this.Restart();
    }
    
}