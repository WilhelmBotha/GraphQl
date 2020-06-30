using System;
using System.Collections.Generic;
using System.Text;

namespace DataContext.Models
{
    public class Server
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string HealthCheckUri { get; set; }
        public string Status { get; set; }
        public string HttpStatus { get; set; }
        public string Body { get; set; }
        public DateTime? LastTimeUp { get; set; }
    }

}
