using System.Collections.Concurrent;

namespace Ilan.Logging;
public interface ICentralLogger
{
    void Log(string msg);
}
public class Logger : ICentralLogger
{
    private readonly IEnumerable<ILogger> _loggers;
    private readonly ConcurrentQueue<string> _messages = new ConcurrentQueue<string>();
    private readonly Task _writeLog;
    public Logger(IEnumerable<ILogger> loggers)
    {
        _loggers = loggers;
        _writeLog = ProcessLogging();
        Task.Run(() => _writeLog);
    }

    public void Log(string message)
    {
        _messages.Enqueue(message);
    }

    private async Task ProcessLogging()
    {
        while (true)
        {
            string msg;
            if (_messages.TryDequeue(out msg))
            {
                foreach (var log in _loggers)
                {
                    log.Log(msg);
                }
            }
            await Task.Delay(1000);

        }
    }
}
