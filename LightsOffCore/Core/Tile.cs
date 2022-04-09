using System;

namespace LightsOff.Core
{
    public class Tile
    {
        public Tile(bool value)
        {
            Value = value;
        }

        public bool Value { get; set; }
    }
}
