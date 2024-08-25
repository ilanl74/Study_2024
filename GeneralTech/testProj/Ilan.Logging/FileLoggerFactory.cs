using System;
using System.IO;
namespace Ilan.Logging;

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
        File.AppendAllText(_path, Environment.NewLine);
    }
}
