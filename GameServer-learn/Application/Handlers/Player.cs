using System.Text;
using GameServer_learn.Application.Interface;
using GameServer_learn.Messaging;
using GameServer_learn.Messaging.Constants;
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
        var url = request.Url;
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
        try
        {
            var wsMess = GameHelper.ParseStruct<WsMessage<object>>(mess);
            switch (wsMess.Tags)
            {
                case WsTags.Invalid:
                    break;
                case WsTags.Login:
                    var loginData = GameHelper.ParseStruct<LoginData>(wsMess.Data.ToString());
                    var x = 10;
                    break;
                case WsTags.Register:
                    break;
                case WsTags.Lobby:
                    break;
                //throw new ArgumentOutOfRangeException();
            }
        }
        catch (Exception e)
        {
            //todo send valid message
            Console.WriteLine(e);
        }
        //((WsGameServer) Server).SendAll($"{this.SessionId} send message {mess}");
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