using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DeliverySchedulerConsumer.Models
{
    public class After
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }

        [JsonPropertyName("customer_id")]
        public int CustomerId { get; set; }

        [JsonPropertyName("order_status")]
        public string OrderStatus { get; set; }

        [JsonPropertyName("total")]
        public Total Total { get; set; }
    }

    public class Field
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }

        [JsonPropertyName("optional")]
        public bool Optional { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("field")]
        public string field { get; set; }

        [JsonPropertyName("version")]
        public int? Version { get; set; }

        [JsonPropertyName("doc")]
        public string Doc { get; set; }

        [JsonPropertyName("parameters")]
        public Parameters Parameters { get; set; }

        [JsonPropertyName("default")]
        public string Default { get; set; }
    }

    public class Parameters
    {
        [JsonPropertyName("allowed")]
        public string Allowed { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("before")]
        public object Before { get; set; }

        [JsonPropertyName("after")]
        public After After { get; set; }

        [JsonPropertyName("source")]
        public Source Source { get; set; }

        [JsonPropertyName("op")]
        public string Op { get; set; }

        [JsonPropertyName("ts_ms")]
        public long TsMs { get; set; }

        [JsonPropertyName("transaction")]
        public object Transaction { get; set; }
    }

    public class DebeziumOrder
    {
        [JsonPropertyName("schema")]
        public Schema Schema { get; set; }

        [JsonPropertyName("payload")]
        public Payload Payload { get; set; }
    }

    public class Schema
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("fields")]
        public List<Field> Fields { get; set; }

        [JsonPropertyName("optional")]
        public bool Optional { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Source
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("connector")]
        public string Connector { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("ts_ms")]
        public long TsMs { get; set; }

        [JsonPropertyName("snapshot")]
        public string Snapshot { get; set; }

        [JsonPropertyName("db")]
        public string Db { get; set; }

        [JsonPropertyName("sequence")]
        public string Sequence { get; set; }

        [JsonPropertyName("schema")]
        public string Schema { get; set; }

        [JsonPropertyName("table")]
        public string Table { get; set; }

        [JsonPropertyName("txId")]
        public int TxId { get; set; }

        [JsonPropertyName("lsn")]
        public int Lsn { get; set; }

        [JsonPropertyName("xmin")]
        public object Xmin { get; set; }
    }

    public class Total
    {
        [JsonPropertyName("scale")]
        public int Scale { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }


}

