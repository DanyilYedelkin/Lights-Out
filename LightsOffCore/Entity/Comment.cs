using System;

namespace LightsOffCore.Entity
{
    [Serializable]
    public class Comment
    {
        public int Id { get; set; }

        public string Player { get; set; }

        public string Comments { get; set; }
        
        public DateTime PlayedAt { get; set; }
    }
}