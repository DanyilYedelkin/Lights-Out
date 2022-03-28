using System;

namespace LightsOff.Core
{
    public class Field
    {
        private readonly Tile[,] _tiles;
        private DateTime startTime;

        public int RowCount { get; set; }
        public int ColumnCount { get; set; }

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
    }
}
