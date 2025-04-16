using Serilog;

namespace GameServer_learn.Logging;

public class GameLogger : IGameLogger
{
    private readonly ILogger _logger;

    public GameLogger()
    {
        _logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("logging/log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }
    public void Print(string msg)
    {
        throw new NotImplementedException();
    }

    public void Info(string info)
    {
        throw new NotImplementedException();
    }

    public void Warning(string ms, Exception exception)
    {
        throw new NotImplementedException();
    }

    public void Error(string error, Exception exception)
    {
        throw new NotImplementedException();
    }

    public void Error(string error)
    {
        throw new NotImplementedException();
    }
}