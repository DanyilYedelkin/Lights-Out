using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using LightsOff.Core;
using LightsOffCore.Service;
using LightsOffCore.Entity;
using LightsOffWeb.Models;

namespace LightsOffWeb.Controllers
{
    public class LightsOff5Controller : Controller
    {
        private const string FieldSessionKey = "field";

        private IScoreService _scoreService = new ScoreServiceEF();
        private ICommentService _commentService = new CommentServiceEF();
        private IRatingService _ratingService = new RatingServiceEF();

        public IActionResult Index()
        {
            var field = new Field(5, 5);
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index", CreateModel());
        }

        public IActionResult Toggle(int x, int y)
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            field.Toggle(x, y);
            if (field.IfWin())
                _scoreService.AddScore(new Score() { PlayedAt = DateTime.Now, Player = "Jaro", Points = field.GetScore() });
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index", CreateModel());
        }

        public IActionResult Coordinate(int tile)
        {
            string coordinates = tile.ToString();
            int x = int.Parse(coordinates[0].ToString()) - 1;
            int y = int.Parse(coordinates[1].ToString()) - 1;
            int type = int.Parse(coordinates[2].ToString());


            var field = (Field)HttpContext.Session.GetObject("field");
            field.SetTypeRegime(type);
            if (type == 1)
            {
                field.Toggle(x, y);
            }
            else
            {
                field.ToggleLine(x, y);
            }
            HttpContext.Session.SetObject("field", field);

            return View("Index", CreateModel());
        }

        public IActionResult ToggleLine(int x, int y)
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            field.ToggleLine(x, y);
            if (field.IfWin())
                _scoreService.AddScore(new Score() { PlayedAt = DateTime.Now, Player = "Jaro", Points = field.GetScore() });
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index", CreateModel());
        }

        public IActionResult SaveScore(Score score)
        {
            var field = (Field)HttpContext.Session.GetObject("field");

            score.Points = field.GetScore();
            score.PlayedAt = DateTime.Now;
            _scoreService.AddScore(score);

            return View("Index", CreateModel());
        }

        public IActionResult SaveComment(Comment comment)
        {
            comment.PlayedAt = DateTime.Now;
            _commentService.AddComment(comment);

            return View("Index", CreateModel());
        }

        public IActionResult SaveRating(Rating rating)
        {
            rating.PlayedAt = DateTime.Now;
            _ratingService.AddRating(rating);

            return View("Index", CreateModel());
        }

        private LightsOffModel CreateModel()
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            var scores = _scoreService.GetTopScores();
            var comments = _commentService.GetComments();
            var ratings = _ratingService.GetRating();


            return new LightsOffModel { Field = field, Scores = scores, Comments = comments, Ratings = ratings };
        }
    }
}
