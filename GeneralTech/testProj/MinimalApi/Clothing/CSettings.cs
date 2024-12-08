using System;

namespace Clothing;

public record struct Version(int Id, DateTime Created, string Explanation);
public class CSettings
{
    public string ConnectionString { get; init; }

    public Version Ver { get; set; }
}
