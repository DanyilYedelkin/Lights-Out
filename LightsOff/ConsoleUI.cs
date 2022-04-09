using LightsOff.Core;
using LightsOffCore.Core;
using LightsOffCore.Entity;
using LightsOffCore.Service;
using System;
using static System.Console;


namespace LightsOff.ConsoleUI
{
    public class ConsoleUI
    {
        private readonly Field _field;      // field (map)
        private DisplayInfo displayInfo;    // all dispay information
        private ChangeLights changeLights;  // changing lights
        
        private readonly IScoreService _scoreService = new ScoreServiceEF();
        private readonly ICommentService _commentService = new CommentServiceEF();
        private readonly IRatingService _ratingService = new RatingServiceEF();

        public ConsoleUI(Field field)
        {
            _field = field;
            changeLights = new ChangeLights(_field);
            displayInfo = new DisplayInfo();
        }

        public void Play()
        {
            PrintInfoDesk();

            while (!_field.IfWin())
            {
                PrintField();
                try
                {
                    var coordinates = ConsoleInput();   // input coordinates to change lights' type

                    try
                    {
                        changeLights.Toggle(coordinates.Item1, coordinates.Item2);
                    }
                    catch (IndexOutOfRangeException indexOutOfMap)
                    {
                        WriteLine("Out of bounds, try again !!!");
                    }
                }
                catch (FormatException invalidTypeVariable)
                {
                    WriteLine("Please type integers !!!");
                }


                WriteLine();
            }

            PrintField();
            WriteLine();

            // add new player with his scores into a score table
            _scoreService.AddScore(
                new Score { Player = Environment.UserName, Points = _field.GetScore(), PlayedAt = DateTime.Now });

            bool repeat = true;
            while (repeat)
            {
                WriteLine("\n\tDo you want to leave a comment and rating? Input: [yes]/[no]");
                string restart = ReadLine().ToLower();

                switch (restart)
                {
                    case "yes":
                    case "y":
                        _commentService.AddComment(
                            new Comment { Player = Environment.UserName, Comments = _field.GetComment(), PlayedAt = DateTime.Now });

                        _ratingService.AddRating(
                            new Rating { Player = Environment.UserName, Ratings = _field.GetRating(), PlayedAt = DateTime.Now });

                        repeat = false;
                        break;
                    case "no":
                    case "n":
                        repeat = false;
                        break;
                    default:
                        WriteLine("\n\tPlease enter the correct command\n");
                        break;
                }
            }

            repeat = LastMessage();
            if (repeat == true) // for repeat a game 
            {
                _field.Initialize();
                Clear();
                Play();
            }
        }

        private void PrintField()
        {
            Write(ToString(_field));
            WriteLine("\nScore: {0}\n", _field.GetScore());
        }

        private string ToString(Field field)    // translate each points of field to string
        {
            if (field is null)
            {
                throw new ArgumentNullException(nameof(field));
            }

            string s = "";

            for (var row = 0; row < field.RowCount; row++)
            {
                s += "\t";
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
            WriteLine("Enter X: ");
            int x = int.Parse(ReadLine());
            WriteLine("Enter Y: ");
            int y = int.Parse(ReadLine());

            return Tuple.Create(x, y);
        }

        private void PrintInfoDesk()
        {
            // top scores ==============================================================
            int position = 1;
            WriteLine("----------------------------------------------------------------");
            WriteLine("------------------------    TOP SCORES   -----------------------");
            foreach (var score in _scoreService.GetTopScores())
            {
                WriteLine(position + ". {0} {1}", score.Player, score.Points);
                position++;
            }
            WriteLine("----------------------------------------------------------------");


            // comments ==============================================================
            position = 1;
            WriteLine("\n----------------------------------------------------------------");
            WriteLine("------------------------    COMMENTS   -------------------------");
            foreach (var comment in _commentService.GetComments())
            {
                WriteLine(position + ". {0}: {1}", comment.Player, comment.Comments);
                position++;
            }
            WriteLine("----------------------------------------------------------------");


            // rating ==============================================================
            position = 1;
            WriteLine("\n----------------------------------------------------------------");
            WriteLine("------------------------    RATING   -------------------------");

            foreach (var rating in _ratingService.GetRating())
            {
                WriteLine(position + ". {0}: {1}", rating.Player, rating.Ratings);
                position++;
            }
            WriteLine("\nGrade Point Average: {0}/5", _ratingService.GetGPA());
            WriteLine("----------------------------------------------------------------");
        }

        private bool LastMessage()
        {
            WriteLine("\tCongratulations, you WIN !!!!\n");

            while (true)
            {
                WriteLine("\n\tDo you want to restart the game? Input: [yes]/[no]");
                string restart = ReadLine().ToLower();

                switch (restart)
                {
                    case "yes":
                    case "y":
                        return true;
                    case "no":
                    case "n":
                        WriteLine("\n\tThanks for playing the game. I wish you will have a good day :D\n");
                        displayInfo.ExitGame();
                        return false;
                    default:
                        WriteLine("\n\tPlease enter the correct command\n");
                        break;
                }
            }
        }
    }
}