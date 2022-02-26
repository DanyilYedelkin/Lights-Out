using LightsOff.Core;
using LightsOffCore.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace LightsOff.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly Field _field;

        public ConsoleUI(Field field)
        {
            _field = field;
        }

        public void Play()
        {
            ChangeLights changeLights = new ChangeLights(_field);


            while (!IfWin())
            {
                PrintField();
                try
                {
                    var coordinates = ConsoleInput();

                    try
                    {
                        changeLights.Toggle(coordinates.Item1, coordinates.Item2);
                    }
                    catch (IndexOutOfRangeException indexOutOfMap)
                    {

                        Console.WriteLine("Out of bounds, try again !!!");
                    }
                }
                catch (FormatException invalidTypeVariable)
                {

                    Console.WriteLine("Please type integers !!!");
                }

                Console.WriteLine();
            }

            EndMessage();
        }

        private void PrintField()
        {
            Console.Write(ToString(_field));
            Console.WriteLine();
        }

        private String ToString(Field field)
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            String s = "";

            for (var row = 0; row < field.RowCount; row++)
            {
                for (var column = 0; column < field.ColumnCount; column++)
                {
                    if (field[row, column].Value)
                    {
                        s += "#";
                    }
                    else
                    {
                        s += ".";
                    }
                }
                s += "\n";
            }
            return s;
        }

        private Tuple<int, int> ConsoleInput()
        {
            Console.WriteLine("Enter X: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y: ");
            int y = int.Parse(Console.ReadLine());

            return Tuple.Create(x, y);
        }

        private bool IfWin()
        {
            bool win = true;

            for (var row = 0; row < _field.RowCount; row++)
            {
                for (var column = 0; column < _field.ColumnCount; column++)
                {
                    if (_field[row, column].Value) win = false;
                }
            }

            return win;
        }

        private void EndMessage()
        {
            if (IfWin())
            {
                Console.WriteLine("Congratulations, you WIN !!!!");
            }
        }

    }
}
