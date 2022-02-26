using LightsOff.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOffCore.Core
{
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

            if (x < _field.RowCount)
            {
                _field[x + 1, y].Value = !_field[x + 1, y].Value;
            }
            if (x > 0)
            {
                _field[x - 1, y].Value = !_field[x - 1, y].Value;
            }
            if (y < _field.ColumnCount)
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
