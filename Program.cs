using Oakton;
using Wolverine;
using Wolverine.Middleware.Problems;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWolverine(x => { x.Policies.AddMiddleware(typeof(StopwatchMiddleware2)); });

var app = builder.Build();

return await app.RunOaktonCommands(args);