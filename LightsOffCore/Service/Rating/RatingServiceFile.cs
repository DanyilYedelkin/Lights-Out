using LightsOffCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace LightsOffCore.Service
{
    public class RatingServiceFile : IRatingService
    {
        private const string FileName = "rating.bin";

        private IList<Rating> _rating = new List<Rating>();

        void IRatingService.AddRating(Rating rating)
        {
            _rating.Add(rating);
            SaveRating();
        }

        double IRatingService.GetGPA()
        {
            int position = 1;
            double sum = 0;
            LoadRating();
            _rating.ToList();

            foreach (var rating in _rating)
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

        IList<Rating> IRatingService.GetRating()
        {
            LoadRating();
            return _rating.ToList();
        }

        void IRatingService.ResetRating()
        {
            _rating.Clear();
            File.Delete(FileName);
        }

        private void SaveRating()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _rating);
            }
        }

        private void LoadRating()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _rating = (List<Rating>)bf.Deserialize(fs);
                }
            }
        }
    }
}
