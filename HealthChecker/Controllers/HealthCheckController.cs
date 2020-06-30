using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GraphQL.Server.Common;
using HealthChecker.GraphQL;
using HealthChecker.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HealthChecker.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response.Headers.Add("Refresh", "5");
            var query = @"{ servers { healthCheckUri id name status } }";
            using var httpClient = new HttpClient();
            var owners = await httpClient.GetAsync($"https://localhost:44323/graphql?query={query}");

            var response = await owners.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<Response<ServerList>>(response);

            return Ok(responseJson);
        }
    }
}
