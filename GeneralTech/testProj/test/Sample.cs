using System;
using Ilan.Logging;

namespace test;

public class Sample
{
    public Sample(ICentralLogger logger)
    {
        logger.Log("this is a test logging");
    }
}
