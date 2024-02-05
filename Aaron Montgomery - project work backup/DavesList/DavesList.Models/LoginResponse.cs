using DavesList.Models.Enums;

namespace DavesList.Models
{
    public record LoginResponse
    {
        public ServerAction ServerAction { get; set; }

        public string? Token { get; set; }
    }
}
