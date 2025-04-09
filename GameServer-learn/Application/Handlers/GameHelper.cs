using Newtonsoft.Json;

namespace GameServer_learn.Application.Handlers;

public static class GameHelper
{
    public static string ParseString<T>(T data)
    {
        return JsonConvert.SerializeObject(data);
    }

    public static T ParseString<T>(string data)
    {
        return JsonConvert.DeserializeObject<T>(data);
    }
}