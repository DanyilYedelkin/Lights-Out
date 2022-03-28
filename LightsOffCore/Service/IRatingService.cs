using System.Collections.Generic;
using LightsOffCore.Entity;


namespace LightsOffCore.Service
{
    public interface IRatingService
    {
        void AddRating(Rating rating);

        IList<Rating> GetRating();

        void ResetRating();

        double GetGPA();
    }
}
