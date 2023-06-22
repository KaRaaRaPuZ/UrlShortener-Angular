using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    public class UrlShortenerController : Controller
    {
        private readonly UrlShortenerService _urlShortenerService;
        private readonly UrlShortenerDbContext _dbContext;
        public UrlShortenerController(UrlShortenerService urlShortenerService, UrlShortenerDbContext dbContext)
        {
            _urlShortenerService = urlShortenerService;
            _dbContext = dbContext;
        }
        //[HttpPost]
        //public IActionResult ShortenUrl(string url)
        //{
        //    if (string.IsNullOrEmpty(url))
        //    {
        //        return BadRequest("Invalid URL");
        //    }
        //    // Generate a short URL
        //    string shortUrl = _urlShortenerService.GenerateShortUrl(url);

        //    // Save the shortened URL to the database
        //    var shortUrlEntity = new ShortUrl
        //    {
        //        OriginalUrl = url,
        //        ShortenedUrl = shortUrl,
        //        CreatedBy = User.Identity.Name,  // Assuming you have authentication set up
        //        CreatedDate = DateTime.UtcNow
        //    };
        //    _dbContext.ShortUrls.Add(shortUrlEntity);
        //    _dbContext.SaveChanges();
        //    // Save the short URL to the database (you will need to inject your DbContext here)

        //    // Redirect to the Short URL Info view with the short URL ID
        //    return RedirectToAction("ShortUrlInfo", new { id = shortUrl });
        //}
    }
}
