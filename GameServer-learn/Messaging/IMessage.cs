namespace GameServer_learn.Messaging;

public interface IMessage<T>
{
    public WsTags Tags{ get; set; }
    public T Data{ get; set; }
}