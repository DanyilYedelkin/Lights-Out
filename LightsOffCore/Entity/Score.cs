using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOffCore.Entity
{
    [Serializable]
    public class Score
    {
        public string Player { get; set; }

        public int Points { get; set; }

        public DateTime PlayedAt { get; set; }
    }
}
