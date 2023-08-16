using Guestline.Battleship.BLL.Ships;

namespace Guestline.Battleship.BLL.Requests
{
    public class PlaceShipRequest
    {
        public Coordinate Coordinate { get; set; }
        public ShipDirection Direction { get; set; }
        public ShipType ShipType { get; set; }
    }
}
