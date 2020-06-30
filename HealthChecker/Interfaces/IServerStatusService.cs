using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.GraphQL;

namespace HealthChecker.Interfaces
{
    public interface IServerStatusService
    {
        List<Server> GetServerStatus();

    }
}
