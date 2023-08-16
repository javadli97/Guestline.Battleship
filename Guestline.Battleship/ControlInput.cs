using Guestline.Battleship.BLL.Requests;
using Guestline.Battleship.BLL.Responses;

namespace Guestline.Battleship
{
    public class ControlInput
    {      
        public static ShipDirection getDirection(string direction)
        {
            switch (direction.ToLower())
            {
                case "l":
                    return ShipDirection.Left;
                case "r":
                    return ShipDirection.Right;
                case "u":
                    return ShipDirection.Up;
                default:
                    return ShipDirection.Down;
            }

        }       
        
        public static PlaceShipRequest GetLocationFromComputer()
        {
            PlaceShipRequest ShipToPlace = new PlaceShipRequest();
            ShipToPlace.Direction = getDirection(GetRandom.GetDirection());
            ShipToPlace.Coordinate = new Coordinate(GetRandom.GetLocation(), GetRandom.GetLocation());
            return ShipToPlace;
        }

        public static Coordinate GetShotLocationFromUser()
        {
            string result = ""; int x, y;
            while (true)
            {
                Console.Write("Which location do you want to shot? ");
                result = Console.ReadLine();
                if (result.Trim().Length > 1)
                {
                    y = GetNumberFromLetter(result.Substring(0, 1));
                    if (y > 0 && int.TryParse(result.Substring(1), out x))
                    {
                        return new Coordinate(x, y);
                    }
                }
            }
        }        

        static int GetNumberFromLetter(string letter)
        {
            int result = -1;
            switch (letter.ToLower())
            {
                case "a":
                    result = 1;
                    break;
                case "b":
                    result = 2;
                    break;
                case "c":
                    result = 3;
                    break;
                case "d":
                    result = 4;
                    break;
                case "e":
                    result = 5;
                    break;
                case "f":
                    result = 6;
                    break;
                case "g":
                    result = 7;
                    break;
                case "h":
                    result = 8;
                    break;
                case "i":
                    result = 9;
                    break;
                case "j":
                    result = 10;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static bool CheckQuit()
        {
            Console.WriteLine("Press F5 to replay or any key to quit...");
            return Console.ReadKey().Key == ConsoleKey.F5;
        }
    }
}
