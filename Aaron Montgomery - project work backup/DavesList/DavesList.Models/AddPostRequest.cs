namespace DavesList.Models
{
    public record AddPostRequest
    {
        public string? Post { get; set; }
        
        public string? Title { get; set; }
    }
}
