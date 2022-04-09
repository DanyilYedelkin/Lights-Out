using LightsOffCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
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
                //return (from s:Score in context.Scores orderby s.Points descending select s).Take(3).ToList();
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
