using System.Text;

namespace UrlShortener.Services
{
    public class UrlShortenerService
    {
        public string GenerateShortUrl(string url)
        {
            var urlHash = url.GetHashCode();
            if (urlHash < 0)
            {
                urlHash *= -1;
            }
            var shortUrl = ConvertToBase62(urlHash);
            return shortUrl;
        }
        private string ConvertToBase62(int number)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var sb = new StringBuilder();

            while (number > 0)
            {
                sb.Insert(0, chars[number % 62]);
                number /= 62;
            }

            return sb.ToString();
        }
    }
}
