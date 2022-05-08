using LightsOff.Core;
using System;

namespace LightsOffCore.Core
{
    [Serializable]
    public class ChangeLights
    {
        private Field _field;

        public ChangeLights(Field field)
        {
            _field = field;
        }

        public void Toggle(int x, int y)
        {
            _field[x, y].Value = !_field[x, y].Value;

            if (x < _field.RowCount - 1)
            {
                _field[x + 1, y].Value = !_field[x + 1, y].Value;
            }
            if (x > 0)
            {
                _field[x - 1, y].Value = !_field[x - 1, y].Value;
            }
            if (y < _field.ColumnCount - 1)
            {
                _field[x, y + 1].Value = !_field[x, y + 1].Value;
            }
            if (y > 0)
            {
                _field[x, y - 1].Value = !_field[x, y - 1].Value;
            }

        }
    }
}
