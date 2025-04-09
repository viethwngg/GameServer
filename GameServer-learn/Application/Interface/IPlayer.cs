namespace GameServer_learn.Application.Interface;

public interface IPlayer
{
    public string SessionId { get; set; }
    public string Name { get; set; }
    void SerDisconnect (bool value);
    bool SendMessage (string message);
    void OnDisconnect ();
}