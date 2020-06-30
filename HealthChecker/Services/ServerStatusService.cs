using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HealthChecker.Interfaces;
using DataContext;
using HealthChecker.GraphQL;

namespace HealthChecker.Services
{
    public class ServerStatusService : IServerStatusService
    {

        private readonly Context _context;
        public ServerStatusService(Context context)
        {
            _context = context;
        }


        public List<Server> GetServerStatus()
        {
            SetServerStatus();

            var serverList = _context.Servers.Select(x => new Server
            {
                Id = x.Id,
                HealthCheckUri = x.HealthCheckUri,
                Name = x.Name,
                Status = x.Status,
                Error = new Error
                {
                    Status = x.HttpStatus,
                    Body = x.Body
                }
            }).ToList();

            return serverList;
        }

        private void SetServerStatus()
        {
            var serverUris = _context.Servers.Select(x => new {x.HealthCheckUri, x.Id});
            foreach (var serverUri in serverUris)
            {
                Task.Run(async() =>
                {
                    using var httpClient = new HttpClient();

                    var response = await httpClient.GetAsync(serverUri.HealthCheckUri);

                    var server = _context.Servers.Find(serverUri.Id);
                    server.HttpStatus = response.StatusCode.ToString();

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        server.Body = await response.Content.ReadAsStringAsync();
                        server.Status = "Down";
                    }
                    else
                    {
                        server.Status = "Up";
                        server.LastTimeUp = DateTime.Now;
                    }

                    _context.Servers.Update(server);
                    await _context.SaveChangesAsync();
                });

            }
        }
    }
}
