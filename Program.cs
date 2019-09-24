using System;
using Couchbase.Configuration.Client;

namespace demo_linq
{
    class Program
    {
        static void Main(string[] args)
        {

        var config = new ClientConfiguration {
            // seems affected by https://github.com/dotnet/standard/issues/542, looks like it's an issue with our transitive dep
            // tried the workaround, it's not working
            BucketConfigs = new Dictionary<string, BucketConfiguration> {
            {"authenticated", new BucketConfiguration {
                PoolConfiguration = new PoolConfiguration {
                    MaxSize = 6,
                    MinSize = 4,
                    SendTimeout = 12000
                },
                DefaultOperationLifespan = 123,
                Password = "password",
                Username = "username",
                BucketName = "authenticated"
            }}
            }
        };

        }
    }
}
