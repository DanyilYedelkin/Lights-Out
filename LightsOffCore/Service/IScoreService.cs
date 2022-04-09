using LightsOffCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOffCore.Service
{
    public interface IScoreService
    {
        void AddScore(Score score);

        IList<Score> GetTopScores();

        void ResetScore();
    }
}
