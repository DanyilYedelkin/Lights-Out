using LightsOffCore.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


namespace LightsOffCore.Service
{
    public class ScoreServiceFile : IScoreService
    {
        private const string FileName = "score.bin";

        private IList<Score> _scores = new List<Score>();

        void IScoreService.AddScore(Score score)
        {
            _scores.Add(score);
            SaveScores();
        }

        IList<Score> IScoreService.GetTopScores()
        {
            LoadScores();
            return _scores.OrderByDescending(s => s.Points).Take(10).ToList();
        }

        void IScoreService.ResetScore()
        {
            _scores.Clear();
            File.Delete(FileName);
        }

        private void SaveScores()
        {
            using (var fs = File.OpenWrite(FileName))
            {
                var bf = new BinaryFormatter();
                bf.Serialize(fs, _scores);
            }
        }

        private void LoadScores()
        {
            if (File.Exists(FileName))
            {
                using (var fs = File.OpenRead(FileName))
                {
                    var bf = new BinaryFormatter();
                    _scores = (List<Score>) bf.Deserialize(fs);
                }
            }
        }

    }
}
