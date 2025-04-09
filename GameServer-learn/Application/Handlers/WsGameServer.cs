using System.Net;
using System.Net.Sockets;
using GameServer_learn.Application.Interface;
using NetCoreServer;

namespace GameServer_learn.Application.Handlers;

public class WsGameServer: WsServer, IWsGameServer
{
    private int _port;
    public WsGameServer(IPAddress address, int port) : base(address, port)
    {
        _port = port;
    }

    protected override TcpSession CreateSession() //user connect vào cổng --> tạo session kết nối
    {
        //todo handle new session 
        Console.WriteLine("New Session connected");
        return base.CreateSession();
    }
    public WsGameServer(IPEndPoint endpoint, int port) : base(endpoint)
    {
        _port = port;
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
        this.Restart();
    }
}