using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LightsOffCore.Service;
using LightsOffCore.Entity;

namespace LightsOffWeb.APIControllers
{
    //https://localhost:44384/api/Score/
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private IScoreService _scoreService = new ScoreServiceEF();

        //GET: /api/Score
        [HttpGet]
        public IEnumerable<Score> GetScores()
        {
            return _scoreService.GetTopScores();
        }

        //POST: /api/Score
        [HttpPost]
        public void PostScore([FromBody]Score score)
        {
            score.PlayedAt = DateTime.Now;
            _scoreService.AddScore(score);
        }
    }
}
