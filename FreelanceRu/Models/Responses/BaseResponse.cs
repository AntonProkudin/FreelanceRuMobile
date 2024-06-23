﻿using System.Text.Json.Serialization;

namespace FreelanceRu.Models.Responses;

public abstract record BaseResponse
{
    [JsonIgnore()]
    public bool Success { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ErrorCode { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Error { get; set; }
}
