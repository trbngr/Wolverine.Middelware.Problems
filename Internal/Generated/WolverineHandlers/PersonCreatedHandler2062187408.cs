// <auto-generated/>
#pragma warning disable

namespace Internal.Generated.WolverineHandlers
{
    // START: PersonCreatedHandler2062187408
    public class PersonCreatedHandler2062187408 : Wolverine.Runtime.Handlers.MessageHandler
    {


        public override System.Threading.Tasks.Task HandleAsync(Wolverine.Runtime.MessageContext context, System.Threading.CancellationToken cancellation)
        {
            var personCreatedHandler = new Wolverine.Middleware.Problems.PersonCreatedHandler();
            // The actual message body
            var personCreated = (Wolverine.Middleware.Problems.PersonCreated)context.Envelope.Message;

            var stopwatch = Wolverine.Middleware.Problems.StopwatchMiddleware2.Before();
            try
            {
                
                // The actual message execution
                personCreatedHandler.Handle(personCreated);

            }

            finally
            {
                Wolverine.Middleware.Problems.StopwatchMiddleware2.Finally(stopwatch, ((Microsoft.Extensions.Logging.ILogger)_loggerForMessage), context.Envelope);
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

    }

    // END: PersonCreatedHandler2062187408
    
    
}
