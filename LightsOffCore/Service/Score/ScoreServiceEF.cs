using LightsOffCore.Entity;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LightsOffCore.Service
{
    public class ScoreServiceEF : IScoreService
    {
        public void AddScore(Score score)
        {
            using (var context = new LightsOffDbContext())
            {
                context.Scores.Add(score);
                context.SaveChanges();
            }
        }

        public IList<Score> GetTopScores()
        {
            using (var context = new LightsOffDbContext())
            {
                return context.Scores.OrderByDescending(s => s.Points).Take(10).ToList();
            }
        }

        public void ResetScore()
        {
            using (var context = new LightsOffDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Scores");
            }
        }
    }
}
