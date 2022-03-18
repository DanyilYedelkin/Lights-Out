using System;
using LightsOff.Core;
using LightsOffCore.Core;
using static System.Console;

namespace LightsOff
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Lights Off - The Game!";   // create a consone name
            DisplayInfo displayInfo = new DisplayInfo();
            displayInfo.RunMainMenu();

            Field field = displayInfo.GetField();    // take the size of map from class DisplayInfo
            var ui = new ConsoleUI.ConsoleUI(field); // create a game
            ui.Play();                               // play the game
        }

    }
}
