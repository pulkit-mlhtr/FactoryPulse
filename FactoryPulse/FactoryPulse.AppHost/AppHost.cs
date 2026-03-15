var builder = DistributedApplication.CreateBuilder(args);

var server = builder.AddProject<Projects.FactoryPulse_API>("server")
    .WithHttpHealthCheck("/health")
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../FactoryPulse.Dashboard")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

await builder.Build().RunAsync();
