﻿namespace DavesList.Models
{
    public record LoginRequest
    {
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
}
