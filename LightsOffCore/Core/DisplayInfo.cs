using LightsOff.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace LightsOffCore.Core
{
    public class DisplayInfo
    {
        private Field field;
        private int x, y;

        public void RunMainMenu()
        {
            // the game's logo in the main menu
            string prompt = @"

             ██▓     ██▓  ▄████  ██░ ██ ▄▄▄█████▓  ██████     ▒█████    █████▒ █████▒
            ▓██▒    ▓██▒ ██▒ ▀█▒▓██░ ██▒▓  ██▒ ▓▒▒██    ▒    ▒██▒  ██▒▓██   ▒▓██   ▒ 
            ▒██░    ▒██▒▒██░▄▄▄░▒██▀▀██░▒ ▓██░ ▒░░ ▓██▄      ▒██░  ██▒▒████ ░▒████ ░ 
            ▒██░    ░██░░▓█  ██▓░▓█ ░██ ░ ▓██▓ ░   ▒   ██▒   ▒██   ██░░▓█▒  ░░▓█▒  ░ 
            ░██████▒░██░░▒▓███▀▒░▓█▒░██▓  ▒██▒ ░ ▒██████▒▒   ░ ████▓▒░░▒█░   ░▒█░    
            ░ ▒░▓  ░░▓   ░▒   ▒  ▒ ░░▒░▒  ▒ ░░   ▒ ▒▓▒ ▒ ░   ░ ▒░▒░▒░  ▒ ░    ▒ ░    
            ░ ░ ▒  ░ ▒ ░  ░   ░  ▒ ░▒░ ░    ░    ░ ░▒  ░ ░     ░ ▒ ▒░  ░      ░      
              ░ ░    ▒ ░░ ░   ░  ░  ░░ ░  ░      ░  ░  ░     ░ ░ ░ ▒   ░ ░    ░ ░    
                ░  ░ ░        ░  ░  ░  ░               ░         ░ ░                 
                                                                         
              Welcome to the Lights Off Simulator. What would you like to do?
       (use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Play", "About", "Exit" }; // command buttons
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RunFirstChoice();   // play the game
                    break;
                case 1:
                    DisplayAboutInfo(); // display some information about the game
                    break;
                case 2:
                    ExitGame();         // exit the game
                    break;
            }
        }

        public void ExitGame()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);  // wait for a key input
            ResetColor();  
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("This game demo was created by Danyil Yedelkin.");
            WriteLine("All information about how to play, you can find in the website " +
                "https://git.kpi.fei.tuke.sk/dotnet-labs/assignments-2022/01-utorok-1330-solanik/dotnet-5650");
            WriteLine("This is just a demo... Full game coming near you soon!");
            WriteLine("\n\nPress any key to return to the menu.");
            ReadKey(true);
            RunMainMenu();
        }

        private void ChoiceColors()
        {
            string prompt = "What color paint would you like to watch dry and backgroud?";
            string[] options = { "Yellow & Magenta", "Green & Black", "White & Black", "Black & White" };
            Menu colorMenu = new Menu(prompt, options);
            int selectedIndex = colorMenu.Run();

            // change colors of words and the background
            switch (selectedIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.Yellow;
                    BackgroundColor = ConsoleColor.DarkMagenta;
                    break;
                case 1:
                    ForegroundColor = ConsoleColor.Green;
                    BackgroundColor = ConsoleColor.Black;
                    break;
                case 2:
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                    break;
                case 3:
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    break;
            }

            Clear();    // clear a console
        }

        private void RunFirstChoice()
        {
            Clear();
            ChoiceColors(); // method for changing colors
            InputSizeMap(); // method for changing map's size
        }

        public void InputSizeMap()
        {
            WriteLine("\tTo get started, enter the size of the game map: ");

            while (true)
            {
                try
                {
                    Write("X: ");
                    x = int.Parse(ReadLine());
                    Write("Y: ");
                    y = int.Parse(ReadLine());

                    if (x > 0 && y > 0)
                    {
                        break;
                    }
                    else
                    {
                        WriteLine("\nPlease, check your map size!\n");
                    }
                }
                catch (FormatException invalidTypeVariable)
                {
                    WriteLine("Please type integers !!!");
                }
            }
            Clear();

            WriteLine("\t\t\tLet's play the Game!!!\n");
            field = new Field(x, y);    // creating a field with new sizes
        }

        public Field GetField()
        {
            return field;
        }
    }
}
