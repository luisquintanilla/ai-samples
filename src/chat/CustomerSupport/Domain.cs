﻿using System.Text.Json.Serialization;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;

public class ManualChunk
{
    [VectorStoreRecordData]
    public int ChunkId { get; set; }

    [VectorStoreRecordKey]
    public int ProductId { get; set; }

    [VectorStoreRecordData]
    public int PageNumber { get; set; }

    [VectorStoreRecordData]
    public required string Text { get; set; }

    [VectorStoreRecordVector(1536, DistanceFunction.CosineSimilarity)]
    public required ReadOnlyMemory<float> Embedding { get; set; }
}

public class Message
{
    public int MessageId { get; set; }

    public DateTime CreatedAt { get; set; }

    public int TicketId { get; set; }

    public bool IsCustomerMessage { get; set; }

    public required string Text { get; set; }
}

public enum TicketStatus
{
    Open,
    Closed,
}
public class Ticket
{
    public int TicketId { get; set; }

    public int? ProductId { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? ShortSummary { get; set; }

    public int CustomerId { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TicketStatus TicketStatus { get; set; }

    public List<Message> Messages { get; set; } = new();

}

