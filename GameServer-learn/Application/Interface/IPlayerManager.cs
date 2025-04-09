using System.Collections.Concurrent;
using System.Collections.Generic;

namespace GameServer_learn.Application.Interface;

public interface IPlayerManager
{
    ConcurrentDictionary<string, IPlayer> Players { get; set; }
    void AddPlayer(IPlayer player);
    void RemovePlayer(string id);
    void RemovePlayer(IPlayer player);
    IPlayer FindPlayer(string id);
    IPlayer FindPlayer(IPlayer player);
    List<IPlayer> GetPlayers();
}