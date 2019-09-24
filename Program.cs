using System;
using Couchbase.Configuration.Client;
using Couchbase;
using System.Collections.Generic;
using System.Linq;
using Couchbase.Linq;
using Newtonsoft.Json;
using Couchbase.Authentication;

namespace demo_linq
{
    class Program
    {
        static void Main(string[] args)
        {      
            ClusterHelper.Initialize(new ClientConfiguration
            {
                Servers = new List<Uri> {new Uri("http://127.0.0.1:8091/")}
            }, new PasswordAuthenticator("Administrator", "password"));

            var context = new BucketContext(ClusterHelper.GetBucket("travel-sample"));
            var query = (from a in context.Query<AirLine>()
                        where a.Country == "United Kingdom"
                        select a).
                        Take(10);

            query.ToList().ForEach(Console.WriteLine);
            ClusterHelper.Close();

            Console.Read();
        }
    }

    public class AirLine
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Iata { get; set; }
        public string Icao { get; set; }
        public string Callsign { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
