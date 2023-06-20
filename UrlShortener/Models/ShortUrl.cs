namespace UrlShortener.Models
{
    public class ShortUrl
    {
        public int Id { get; set; }  // Primary Key
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string CreatedBy { get; set; }  // The user who created the URL
        public DateTime CreatedDate { get; set; }
    }
}
