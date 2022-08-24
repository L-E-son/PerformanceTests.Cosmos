using Microsoft.Azure.Cosmos;
using System;

namespace PerformanceTests.Cosmos
{
    public static class CosmosInstances
    {
        public static CosmosClient StandardClient { get; }

        public static CosmosClient BulkExectionClient { get; }

        public static Container Standard { get; }

        public static Container BulkExection { get; }

        static CosmosInstances()
        {
            var connectionString = Environment.GetEnvironmentVariable("CosmosConnectionString");

            StandardClient = new CosmosClient(connectionString, new CosmosClientOptions { AllowBulkExecution = false, EnableContentResponseOnWrite = false });
            BulkExectionClient = new CosmosClient(connectionString, new CosmosClientOptions { AllowBulkExecution = true, EnableContentResponseOnWrite = false });

            Standard = StandardClient.GetContainer("non_provisioned", "container");
            BulkExection = BulkExectionClient.GetContainer("non_provisioned", "container");
        }
    }
}
