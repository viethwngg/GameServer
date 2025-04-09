using System.Text;
using GameServer_learn.Application.Interface;
using NetCoreServer;

namespace GameServer_learn.Application.Handlers;

public class Player: WsSession, IPlayer
{
    public string SessionId { get; set; }
    public string Name { get; set; }
    private bool IsDisconnected { get; set; }
    public Player(WsServer server, string name) : base(server)
    {
        Name = name;
        SessionId = this.Id.ToString();
        IsDisconnected = false;
    }

    public override void OnWsConnected(HttpRequest request)
    {
        //todo login on player connected
        Console.WriteLine("Player connected");
        IsDisconnected = false;
    }

    public override void OnWsDisconnected()
    {
        OnDisconnect();
        base.OnWsDisconnected();
    }

    public override void OnWsReceived(byte[] buffer, long offset, long size)
    {
        var mess = Encoding.UTF8.GetString(buffer, (int)offset, (int)size);
        Console.WriteLine($"Client {SessionId} sent message: {mess}");
        ((WsGameServer) Server).SendAll($"{this.SessionId}send message: {mess}");
    }
    
    public void SerDisconnect(bool value)
    {
        this.IsDisconnected = value;
    }

    public bool SendMessage(string message)
    {
        return this.SendTextAsync(message);
    }

    public void OnDisconnect()
    {
        //todo logic handle player disconnect
        Console.WriteLine(this.SessionId + " has disconnected");
        //((WsGameServer)Server).PlayerManager.RemovePlayer(this);
    }
}