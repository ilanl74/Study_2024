using System;
using System.Text;
using System.Text.Json;

namespace Clothing;

public class CMiddleware : IMiddleware
{
    static int _counter = 0;
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        Console.WriteLine("start CMiddleware InvokeAsync");
        context.Request.EnableBuffering();
        bool found = false;
        using (var stream = new StreamReader(context.Request.Body, Encoding.UTF8, leaveOpen: true))
        {
            bool continueReading = true;

            while (continueReading && !found)
            {
                var str = await stream.ReadLineAsync();
                if (str == null)
                    continueReading = false;
                else if (str.Contains("Test"))
                    found = true;
                else if (str.Contains("Stam"))
                {
                    context.Items.Add("Stam", new AData(_counter, $"really_{_counter++}"));

                }
            }

            context.Request.Body.Position = 0;

        }
        if (!found)
        {
            await next(context);
        }

        Console.WriteLine("after CMiddleware InvokeAsync");

    }
}
public static class CMiddlewareExtension
{
    public static IServiceCollection AddCMiddleware(this IServiceCollection services)
    {
        services.AddSingleton<CMiddleware>();
        return services;
    }
}