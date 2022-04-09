using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightsOffCore.Service;
using LightsOffCore.Entity;

namespace LightsOffWeb.APIControllers
{
    //https://localhost:44371/api/Rating/
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingService ratingService = new RatingServiceEF();

        //GET: /api/Rating
        [HttpGet]
        public IEnumerable<Rating> GetRating()
        {
            return ratingService.GetRating();
        }

        //POST: /api/Rating
        [HttpPost]
        public void PostComment([FromBody] Rating rating)
        {
            //rating.PlayedAt = DateTime.Now;
            ratingService.AddRating(rating);
        }
    }
}
