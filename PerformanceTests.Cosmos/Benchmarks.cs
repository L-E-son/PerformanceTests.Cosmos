using BenchmarkDotNet.Attributes;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceTests.Cosmos
{
    [MarkdownExporter]
    public class Benchmarks
    {
        [Params(1, 10, 100, 1_000)]
        public int N { get; set; }

        [Params(6_461)]
        public int DocumentSizeInBytes { get; set; }

#pragma warning disable CS8618
        private CosmosDocument[] _defaultDocuments;
        private CosmosDocument[] _bulkDocuments;
#pragma warning restore CS8618

        [GlobalSetup]
        public void GlobalSetup()
        {
            _defaultDocuments = DocumentGenerator.GenerateDocuments(N, DocumentSizeInBytes).ToArray();
            _bulkDocuments = DocumentGenerator.GenerateDocuments(N, DocumentSizeInBytes).ToArray();
        }

        [Benchmark]
        public async Task DefaultExecution()
        {
            foreach (var doc in _defaultDocuments)
            {
                var id = doc.id;
                var pk = new PartitionKey(id);

                await CosmosInstances.Standard.UpsertItemAsync(doc, pk);
            }
        }

        [Benchmark]
        public async Task BulkExecution()
        {
            var tasks = new List<Task>();

            foreach (var doc in _bulkDocuments)
            {
                var id = doc.id;
                var pk = new PartitionKey(id);

                var saveTask = CosmosInstances.BulkExection.UpsertItemAsync(doc, pk);
                tasks.Add(saveTask);
            }

            await Task.WhenAll(tasks);
        }

        [GlobalCleanup]
        public async Task GlobalCleanup()
        {
            await Task.Delay(5_000);
        }
    }
}
