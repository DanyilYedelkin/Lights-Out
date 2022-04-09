using Microsoft.EntityFrameworkCore;
using System;


namespace LightsOffCore.Entity
{
    [Serializable]
    public class Rating
    {
        public int Id { get; set; }
        
        public string Player { get; set; }

        public double Ratings { get; set; }

        public DateTime PlayedAt { get; set; }
    }
}
