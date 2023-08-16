using Guestline.Battleship.BLL.GameLogic;
using Guestline.Battleship.BLL.Requests;
using Guestline.Battleship.BLL.Responses;
using Guestline.Battleship.BLL.Ships;

namespace Guestline.Battleship
{
    public class GameSetup
    {
        public GameState _gm;
        public GameSetup(GameState gm)
        {
            _gm = gm;
        }

        public void SetBoard()
        {
            PlaceShipOnBoard(_gm.Board);
            Console.WriteLine("All ship were placed successfull! Press any key to continue...");
            Console.ReadKey();
        }

        public void PlaceShipOnBoard(Board board)
        {
            PlaceShipRequest ShipToPlace = new PlaceShipRequest();
            ShipPlacement result;
            do
            {
                ShipToPlace = ControlInput.GetLocationFromComputer();
                ShipToPlace.ShipType = ShipType.Battleship;
                result = board.PlaceShip(ShipToPlace);
            } while (result != ShipPlacement.Ok);
            do
            {
                ShipToPlace = ControlInput.GetLocationFromComputer();
                ShipToPlace.ShipType = ShipType.Destroyer;
                result = board.PlaceShip(ShipToPlace);
            } while (result != ShipPlacement.Ok);
            do
            {
                ShipToPlace = ControlInput.GetLocationFromComputer();
                ShipToPlace.ShipType = ShipType.Destroyer;
                result = board.PlaceShip(ShipToPlace);
            } while (result != ShipPlacement.Ok);
        }
    }
}
