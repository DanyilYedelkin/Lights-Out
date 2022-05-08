using System;

namespace LightsOff.Core
{
    [Serializable]
    public class Tile
    {
        public Tile(bool value)
        {
            Value = value;
        }

        public bool Value { get; set; }
    }
}
