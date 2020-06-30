using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataContext;
using GraphQL;
using GraphQL.Types;
using HealthChecker.Interfaces;
using HealthChecker.Services;

namespace HealthChecker.GraphQL
{

    public class Server
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HealthCheckUri { get; set; }
        public string Status { get; set; }
        public Error Error { get; set; }
    }

    public class Error
    {
        public string Status { get; set; }
        public string Body { get; set; }
    }

    public class ErrorType : ObjectGraphType<Error>
    {
        public ErrorType()
        {
            Name = "Error";
            Description = "Server Error";

            Field(h => h.Status);
            Field(h => h.Body);
        }
    }

    public class ServerType : ObjectGraphType<Server>
    {
        public ServerType()
        {
            Name = "Server";
            Description = "A server to monitor";

            Field(h => h.Id);
            Field(h => h.Name);
            Field(h => h.HealthCheckUri);
            Field(h => h.Status);
            Field(h => h.Error, type: typeof(ErrorType));

        }
    }

    public class HealthCheckerQuery : ObjectGraphType<object>
    {
        public HealthCheckerQuery(IServerStatusService _serverStatusService)
        {
            Name = "Query";
            Func<ResolveFieldContext, string, object> serverResolver = (context, id) => _serverStatusService.GetServerStatus();

            FieldDelegate< ListGraphType<ServerType>>(
                "servers",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "id", Description = "id of server" }
                ),
                resolve: serverResolver
            );
        }
    }

    public class HealthCheckerSchema : Schema
    {
        private static readonly Context _context = new Context();
        private readonly IServerStatusService _serverStatusService = new ServerStatusService(_context);
        public HealthCheckerSchema(IServiceProvider provider) : base(provider)
        {
            Query = new HealthCheckerQuery(_serverStatusService);
        }
    }
}
