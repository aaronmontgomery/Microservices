using DavesList.Models.Enums;

namespace DavesList.Models
{
    public record LogoutResponse
    {
        public bool IsLoggedIn { get; set; }

        public ServerAction ServerAction { get; set; }
    }
}
