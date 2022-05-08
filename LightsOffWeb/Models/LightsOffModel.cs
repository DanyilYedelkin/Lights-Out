using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightsOff.Core;
using LightsOffCore.Entity;

namespace LightsOffWeb.Models
{
    public class LightsOffModel
    {
        public Field Field { get; set; }

        public IList<Score> Scores { get; set; }

        public IList<Rating> Ratings { get; set; }

        public IList<Comment> Comments { get; set; }
    }
}
