using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data;
using UrlShortener.Models;
using UrlShortener.Services;

namespace UrlShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : Controller
    {
        private readonly UrlShortenerDbContext _dbContext;
        private readonly UrlShortenerService _urlShortenerService;
        public UrlController(UrlShortenerDbContext dbContext, UrlShortenerService urlShortenerService)
        {
            _dbContext = dbContext;
            _urlShortenerService = urlShortenerService;
        }

        [HttpGet]
        public IActionResult GetAllShortUrls()
        {
            var shortUrls = _dbContext.ShortUrls.ToList();
            return Ok(shortUrls);
        }

        [HttpGet("{id}")]
        public IActionResult GetShortUrl(int id)
        {
            var shortUrl = _dbContext.ShortUrls.Find(id);
            if (shortUrl == null)
            {
                return NotFound();
            }

            return Ok(shortUrl);
        }

        [HttpPost]
        public IActionResult CreateShortUrl([FromBody] string originalUrl)
        {
            string shortenedUrl = _urlShortenerService.GenerateShortUrl(originalUrl);
            var shortUrl = new ShortUrl(originalUrl, shortenedUrl);
            if (ModelState.IsValid)
            {
                // Save the shortUrl to the database
                _dbContext.ShortUrls.Add(shortUrl);
                _dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetShortUrl), new { id = shortUrl.Id }, shortUrl);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShortUrl(int id)
        {
            var shortUrl = _dbContext.ShortUrls.Find(id);
            if (shortUrl == null)
            {
                return NotFound();
            }

            _dbContext.ShortUrls.Remove(shortUrl);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
