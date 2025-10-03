using Azure;
using Azure.Data.Tables;

namespace AzureTableMvc.Models
{
    public class PersonEntity : ITableEntity
    {
        public PersonEntity() { }

        public PersonEntity(string partitionKey, string rowKey)
        {
            PartitionKey = partitionKey;
            RowKey = rowKey;
        }

        public string PartitionKey { get; set; } = string.Empty;
        public string RowKey { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public ETag ETag { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
    }
}
