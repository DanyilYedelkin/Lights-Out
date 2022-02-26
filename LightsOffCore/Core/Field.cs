using LightsOffCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LightsOff.Core
{
    public class Field
    {
        private readonly Tile[,] _tiles;
        private Coordinate _emptyTileCoordinate;

        public int RowCount { get; }
        public int ColumnCount { get; }

        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            _tiles = new Tile[rowCount, columnCount];
            Initialize();
        }


        public Tile this[int row, int column]
        {
            get { return _tiles[row, column]; }
            set { _tiles[row, column] = value; }
        }

        private void Initialize()
        {
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    Random rand = new Random();
                    bool value = rand.Next(2) == 0;

                    _tiles[row, column] = new Tile(value);
                }
            }
        }

    }
}
