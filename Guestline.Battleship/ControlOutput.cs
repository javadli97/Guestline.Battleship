using Guestline.Battleship.BLL.GameLogic;
using Guestline.Battleship.BLL.Requests;
using Guestline.Battleship.BLL.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guestline.Battleship
{
    class ControlOutput
    {
        static int counttime = 0;



        static string GetLetterFromNumber(int number)
        {
            string result = "";
            switch (number)
            {
                case 1:
                    result = "A";
                    break;
                case 2:
                    result = "B";
                    break;
                case 3:
                    result = "C";
                    break;
                case 4:
                    result = "D";
                    break;
                case 5:
                    result = "E";
                    break;
                case 6:
                    result = "F";
                    break;
                case 7:
                    result = "G";
                    break;
                case 8:
                    result = "H";
                    break;
                case 9:
                    result = "I";
                    break;
                case 10:
                    result = "J";
                    break;
                default:
                    break;
            }
            return result;
        }

        public static void DrawHistory(Board board)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("  ");
            for (int y = 1; y <= 10; y++)
            {
                Console.Write(GetLetterFromNumber(y) + " ");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            for (int x = 1; x <= 10; x++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(x);
                Console.Write(" ");
                Console.ForegroundColor = ConsoleColor.White;
                for (int y = 1; y <= 10; y++)
                {
                    //Console.Write(y);
                    ShotHistory history = board.CheckCoordinate(new Coordinate(x, y));
                    switch (history)
                    {
                        case ShotHistory.Hit:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("H");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case ShotHistory.Sunk:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("S");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                        case ShotHistory.Miss:
                            Console.Write("M");
                            break;
                        case ShotHistory.Unknown:
                            Console.Write(" ");
                            break;
                    }
                    Console.Write("|");
                }
                Console.WriteLine();
            }
            Console.WriteLine("");
        }

        public static void ShowShotResult(FireShotResponse shotresponse, Coordinate c, string playername)
        {
            String str = "";
            switch (shotresponse.ShotStatus)
            {
                case ShotStatus.Duplicate:
                    Console.ForegroundColor = ConsoleColor.Red;
                    str = "Shot location: " + c.XCoordinate +  GetLetterFromNumber(c.YCoordinate) + "\t result: Duplicate shot location!";
                    break;
                case ShotStatus.Hit:
                    Console.ForegroundColor = ConsoleColor.Green;
                    str = "Shot location: " + c.XCoordinate + GetLetterFromNumber(c.YCoordinate) + "\t result: Hit!";
                    break;
                case ShotStatus.HitAndSunk:
                    Console.ForegroundColor = ConsoleColor.Green;
                    str = "Shot location: " + c.XCoordinate + GetLetterFromNumber(c.YCoordinate) + "\t result: Hit and Sunk, " + shotresponse.ShipImpacted + "!";
                    break;
                case ShotStatus.Invalid:
                    Console.ForegroundColor = ConsoleColor.Red;
                    str = "Shot location: " + c.XCoordinate + GetLetterFromNumber(c.YCoordinate) + "\t result: Invalid hit location!";
                    break;
                case ShotStatus.Miss:
                    Console.ForegroundColor = ConsoleColor.White;
                    str = "Shot location: " + c.XCoordinate + GetLetterFromNumber(c.YCoordinate) + "\t result: Miss!";
                    break;
                case ShotStatus.Victory:
                    Console.ForegroundColor = ConsoleColor.Green;
                    str = "Shot location: " + c.XCoordinate + GetLetterFromNumber(c.YCoordinate) + "\t result: Hit and Sunk, " + shotresponse.ShipImpacted + "! \n\n";
                    str += "       ******\n";
                    str += "       ******\n";
                    str += "        **** \n";
                    str += "         **  \n";
                    str += "         **  \n";
                    str += "       ******\n";
                    str += "Game Over, " + playername + " wins!";
                    break;
            }
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
        }


        public static void ResetScreen()
        {
            Console.Clear();
        }
    }
}
