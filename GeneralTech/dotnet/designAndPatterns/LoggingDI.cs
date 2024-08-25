public interface ILogger
{
    void Log(string message);
}

public class FileLoggerFactory : ILogger
{
    private readonly string _path;
    public FileLoggerFactory(string path)
    {
        _path = path;
    }
    public void Log(string message)
    {
        File.AppendAllText(_path, message);
    }
}

public class Logger : ILogger
{
    private IEnumerable<ILogger> _loggers;

    public Logger(IEnumerable<ILogger> loggers)
    {

    }
}