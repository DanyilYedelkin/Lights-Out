using System;
using LightsOff.Core;


namespace LightsOff
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new Field(5, 5);
            var ui = new ConsoleUI.ConsoleUI(field);
            ui.Play();
        }
    }
}
