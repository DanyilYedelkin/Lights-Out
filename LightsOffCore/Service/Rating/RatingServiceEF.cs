using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using LightsOffCore.Entity;

namespace LightsOffCore.Service
{
    public class RatingServiceEF : IRatingService
    {
        public void AddRating(Rating rating)
        {
            using (var context = new LightsOffDbContext())
            {
                context.Ratings.Add(rating);
                context.SaveChanges();
            }
        }

        public double GetGPA()
        {
            using (var context = new LightsOffDbContext())
            {
                int position = 1;
                double sum = 0;

                foreach (var rating in context.Ratings.ToList())
                {
                    sum += rating.Ratings;
                    position++;
                }

                if (sum == 0) return 0;
                else
                {
                    return Math.Round((sum / (position - 1)), 2);
                }
            }
        }

        public IList<Rating> GetRating()
        {
            using (var context = new LightsOffDbContext())
            {
                //return context.Ratings.ToList();
                return context.Ratings.OrderByDescending(c => c.PlayedAt).ToList();
            }
        }

        public void ResetRating()
        {
            using (var context = new LightsOffDbContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Ratings");
            }
        }
    }
}
