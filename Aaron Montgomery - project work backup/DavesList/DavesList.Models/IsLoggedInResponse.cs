using DavesList.Models.Enums;

namespace DavesList.Models
{
    public record IsLoggedInResponse
    {
        public bool IsLoggedIn { get; set; }

        public ServerAction ServerAction { get; set; }
    }
}
