using Guestline.Battleship.BLL.GameLogic;
using Guestline.Battleship.BLL.Requests;
using Guestline.Battleship.BLL.Responses;
using Guestline.Battleship.BLL.Ships;

namespace Guestline.Battleship.Tests
{
    [TestFixture]
    public class FireShotTests
    {
        private Board SetupBoard()
        {
            Board board = new Board();

            PlaceDestroyer(board);
            PlaceBattleship(board);

            return board;
        }

        private void PlaceBattleship(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(5, 10),
                Direction = ShipDirection.Down,
                ShipType = ShipType.Battleship
            };

            board.PlaceShip(request);
        }

        private void PlaceDestroyer(Board board)
        {
            var request = new PlaceShipRequest()
            {
                Coordinate = new Coordinate(1, 1),
                Direction = ShipDirection.Right,
                ShipType = ShipType.Destroyer
            };

            board.PlaceShip(request);

            request.Coordinate= new Coordinate(5, 5);
            request.Direction= ShipDirection.Down;
            board.PlaceShip(request);

        }


        [Test]
        public void CoordinateEquality()
        {
            var c1 = new Coordinate(5, 10);
            var c2 = new Coordinate(5, 10);

            Assert.AreEqual(c1, c2);
        }

        [Test]
        public void CanNotFireOffBoard()
        {
            var board = SetupBoard();

            var coordinate = new Coordinate(15, 20);

            var response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Invalid, response.ShotStatus);
        }

        [Test]
        public void CanNotFireDuplicateShot()
        {
            var board = SetupBoard();

            var coordinate = new Coordinate(1, 5);
            var response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Miss, response.ShotStatus);

            // fire same shot
            response = board.FireShot(coordinate);
            Assert.AreEqual(ShotStatus.Duplicate, response.ShotStatus);
        }

        [Test]
        public void CanMissShip()
        {
            var board = SetupBoard();

            var coordinate = new Coordinate(1, 5);
            var response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Miss, response.ShotStatus);
        }

        [Test]
        public void CanHitShip()
        {
            var board = SetupBoard();

            var coordinate = new Coordinate(1, 3);
            var response = board.FireShot(coordinate);

            Assert.AreEqual(ShotStatus.Hit, response.ShotStatus);
            Assert.AreEqual("Destroyer", response.ShipImpacted);
        }
    }
}
