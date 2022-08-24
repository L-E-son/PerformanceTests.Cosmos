using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceTests.Cosmos
{
    public static class DocumentGenerator
    {
        public static IEnumerable<CosmosDocument> GenerateDocuments(int documentCount, int documentSizeInBytes)
        {
            var documentContent = FixedSizeStringGenerator.GetStringOfSize(documentSizeInBytes);

            for (int i = 0; i < documentCount; i++)
            {
                yield return new CosmosDocument
                {
                    id = i.ToString(),
                    content = documentContent
                };
            }
        }
    }
}
