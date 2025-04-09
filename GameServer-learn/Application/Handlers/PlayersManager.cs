using System.Collections.Concurrent;
using GameServer_learn.Application.Interface;

namespace GameServer_learn.Application.Handlers;

public class PlayersManager: IPlayerManager
{
    public ConcurrentDictionary<string, IPlayer> Players { get; set; }
    //ccu 
    public PlayersManager()
    {
        Players = new ConcurrentDictionary<string, IPlayer>();
    }
    public void AddPlayer(IPlayer player)
    {
        if (FindPlayer(player) == null)
        {
            Players.TryAdd(player.SessionId, player);
            Console.WriteLine($"Player {player.SessionId} added");
            Console.WriteLine($"List Player {Players.Count} added");
        }
        
    }

    public void RemovePlayer(string id)
    {
        if (FindPlayer(id) != null)
        {
            Players.TryRemove(id, out var player);
            if (player != null)
            {
                Console.WriteLine($"Player {player.SessionId} removed");
                Console.WriteLine($"List Player {Players.Count} ");
            }
        }
    }

    public void RemovePlayer(IPlayer player)
    {
        this.RemovePlayer(player.SessionId);
    }

    public IPlayer FindPlayer(string id)
    {
        return Players.FirstOrDefault(p => p.Value.SessionId == id).Value;
    }

    public IPlayer FindPlayer(IPlayer player)
    {
        return Players.FirstOrDefault(p=> p.Value.Equals(player)).Value;
    }

    public List<IPlayer> GetPlayers() => Players.Values.ToList();
    
}