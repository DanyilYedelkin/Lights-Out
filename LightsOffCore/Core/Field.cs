using System;
using System.Linq;

namespace LightsOff.Core
{
    [Serializable]
    public class Field
    {
        private readonly Tile[,] _tiles;
        private DateTime startTime;
        private int typeRegime;

        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            _tiles = new Tile[rowCount, columnCount];
            typeRegime = 1;
            Initialize();
        }


        public Tile this[int row, int column]
        {
            get { return _tiles[row, column]; }
            set { _tiles[row, column] = value; }
        }

        public void Initialize()
        {
            startTime = DateTime.Now;
            
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

        public bool IfWin()
        {
            bool win = true;

            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    if (_tiles[row, column].Value) win = false;
                }
            }

            return win;
        }

        public void AI()
        {
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    if (_tiles[row, column].Value) _tiles[row, column].Value = false;
                }
            }
        }

        public bool typeOfTile(int row, int column)
        {
            return _tiles[row, column].Value;
        }

        public int GetScore()
        {
            return RowCount * ColumnCount + 1000 - (DateTime.Now - startTime).Seconds;
        }

        public string GetComment()
        {
            Console.WriteLine("\nInput your comment:");
            return Console.ReadLine();
        }

        public double GetRating()
        {
            Console.WriteLine("\nInput your rating (0-5):");
            double rate = double.Parse(Console.ReadLine());

            while (rate > 5 || rate < 0)
            {
                Console.WriteLine("Incorrect input! Please, input your rating (0-5):");
                rate = double.Parse(Console.ReadLine());
            }
            return rate;
        }

        public void Toggle(int x, int y)
        {
            this[x, y].Value = !this[x, y].Value;

            if (x < this.RowCount - 1)
            {
                this[x + 1, y].Value = !this[x + 1, y].Value;
            }
            if (x > 0)
            {
                this[x - 1, y].Value = !this[x - 1, y].Value;
            }
            if (y < this.ColumnCount - 1)
            {
                this[x, y + 1].Value = !this[x, y + 1].Value;
            }
            if (y > 0)
            {
                this[x, y - 1].Value = !this[x, y - 1].Value;
            }
        }

        public void ToggleLine(int x, int y)
        {
            this[x, y].Value = !this[x, y].Value;
            int memoryX = x, memoryY = y;

            while (x < this.RowCount - 1)
            {
                this[x + 1, y].Value = !this[x + 1, y].Value;
                x++;
            }
            x = memoryX;
            while (x > 0)
            {
                this[x - 1, y].Value = !this[x - 1, y].Value;
                x--;
            }
            x = memoryX;
            while (y < this.ColumnCount - 1)
            {
                this[x, y + 1].Value = !this[x, y + 1].Value;
                y++;
            }
            y = memoryY;
            while (y > 0)
            {
                this[x, y - 1].Value = !this[x, y - 1].Value;
                y--;
            }
            y = memoryY;
        }

        public int GetTypeRegime()
        {
            return typeRegime;
        }

        public void SetTypeRegime(int newType)
        {
            typeRegime = newType;
        }

    }
}
