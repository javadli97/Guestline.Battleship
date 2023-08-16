using Guestline.Battleship.BLL.Ships;

namespace Guestline.Battleship.BLL.GameLogic
{
    public class ShipCreator
    {
        public static Ship CreateShip(ShipType type)
        {
            switch (type)
            {
                case ShipType.Destroyer:
                    return new Ship(ShipType.Destroyer, 4);

                default:
                    return new Ship(ShipType.Battleship, 5);
            }
        }
    }
}
