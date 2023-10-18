using System.Diagnostics;
using System.Runtime.CompilerServices;
using JasperFx.Core;
using Wolverine.Http;

namespace Wolverine.Middleware.Problems;

public record CreatePerson;

public record PersonCreated(Guid Id);

public record PersonCreatedResponse(Guid Id) : CreationResponse($"/people/{Id}");

public class CreatePersonHandler
{
    [WolverinePost("/people")]
    public (PersonCreatedResponse, IEnumerable<object> ) Handle(CreatePerson command)
    {
        var id = CombGuidIdGeneration.NewGuid();

        return (
            new PersonCreatedResponse(id),
            new[] { new PersonCreated(id) }
        );
    }
}

public class PersonCreatedHandler
{
    public void Handle(PersonCreated e) => Console.Out.WriteLine(e);
}

public static class StopwatchMiddleware2
{
    // The Stopwatch being returned from this method will
    // be passed back into the later method
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Stopwatch Before()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        return stopwatch;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void Finally(Stopwatch stopwatch, ILogger logger, Envelope envelope)
    {
        stopwatch.Stop();
        logger.LogDebug("Envelope {Id} / {MessageType} ran in {Duration} milliseconds",
            envelope.Id, envelope.MessageType, stopwatch.ElapsedMilliseconds);
    }
}